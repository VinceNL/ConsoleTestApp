using System.ComponentModel;

namespace EventDelegationExample
{
    public class Device : IDevice
    {
        private const double WarningLevel = 27;
        private const double EmergencyLevel = 75;

        public double WarningTemperatureLevel => WarningLevel;

        public double EmergencyTemperatureLevel => EmergencyLevel;

        public void HandleEmergency()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine("Sending out notifications to emergency services...");
            Console.ResetColor();
            ShutDownDevice();
            Console.WriteLine();
        }

        private void ShutDownDevice()
        {
            Console.WriteLine("Device is shutting down");
        }

        public void RunDevice()
        {
            Console.WriteLine("Device is running");

            ICoolingMechanism coolingMechanism = new CoolingMechanism();
            IHeatSensor heatSensor = new HeatSensor(WarningLevel, EmergencyLevel);
            IThermoStat thermostat = new Thermostat(heatSensor, coolingMechanism, this);

            thermostat.RunThermoStat();
        }
    }

    public class Thermostat : IThermoStat
    {
        private ICoolingMechanism _coolingMechanism = null;
        private IHeatSensor _heatSensor = null;
        private IDevice _device = null;

        public Thermostat(IHeatSensor heatSensor, ICoolingMechanism coolingMechanism, IDevice device)
        {
            _heatSensor = heatSensor;
            _coolingMechanism = coolingMechanism;
            _device = device;
        }

        private void WireUpEventsToEventHandlers()
        {
            _heatSensor.TemperatureReachesEmergencyLevelEventHandler += HeatSensor_TemperatureReachesEmergencyLevelEventHandler;
            _heatSensor.TemperatureReachesWarningLevelEventHandler += HeatSensor_TemperatureReachesWarningLevelEventHandler;
            _heatSensor.TemperatureFallsBelowWarningLevelEventHandler += HeatSensor_TemperatureFallsBelowWarningLevelEventHandler;
        }

        private void HeatSensor_TemperatureFallsBelowWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine($"Information Alert!! (Temperature fell below warning level of {_device.WarningTemperatureLevel})");
            _coolingMechanism.Off();
            Console.ResetColor();
        }

        private void HeatSensor_TemperatureReachesEmergencyLevelEventHandler(object? sender, TemperatureEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"Emergency Alert!! (Emergency level is {_device.EmergencyTemperatureLevel} and above");
            _device.HandleEmergency();
            Console.ResetColor();
        }

        private void HeatSensor_TemperatureReachesWarningLevelEventHandler(object? sender, TemperatureEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine($"Warning Alert!! (Warning level is between {_device.WarningTemperatureLevel} and  {_device.EmergencyTemperatureLevel}");
            _coolingMechanism.On();
            Console.ResetColor();
        }

        public void RunThermoStat()
        {
            Console.WriteLine("Thermostat is running..");
            WireUpEventsToEventHandlers();
            _heatSensor.RunHeatSensor();
        }
    }

    public interface IThermoStat
    {
        void RunThermoStat();
    }

    public interface IDevice
    {
        double WarningTemperatureLevel { get; }
        double EmergencyTemperatureLevel { get; }

        void RunDevice();

        void HandleEmergency();
    }

    public class CoolingMechanism : ICoolingMechanism
    {
        public void Off()
        {
            Console.WriteLine();
            Console.WriteLine("Cooling mechanism is off");
            Console.WriteLine();
        }

        public void On()
        {
            Console.WriteLine();
            Console.WriteLine("Cooling mechanism is on");
            Console.WriteLine();
        }
    }

    public interface ICoolingMechanism
    {
        void On();

        void Off();
    }

    public class HeatSensor : IHeatSensor
    {
        private double _warningLevel = 0;
        private double _emergencyLevel = 0;

        private bool _hasReachedWarningTemperature = false;

        protected EventHandlerList _listEventDelegates = new EventHandlerList();

        private static readonly object _temperatureReachesWarningLevelKey = new object();
        private static readonly object _temperatureFallsBelowWarningLevelKey = new object();
        private static readonly object _temperatureReachesEmergencyLevelKey = new object();

        private double[] _temperateData = null;

        public HeatSensor(double warningLevel, double emergencyLevel)
        {
            _emergencyLevel = emergencyLevel;
            _warningLevel = warningLevel;

            SeedData();
        }

        private void MonitorTemperature()
        {
            foreach (var temperate in _temperateData)
            {
                Console.ResetColor();
                Console.WriteLine($"DateTime: {DateTime.Now}, Current temperature: {temperate}");

                if (temperate >= _emergencyLevel)
                {
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temperate,
                        CurrentDateTime = DateTime.Now
                    };
                    OnTemperatureReachesEmergencyLevel(e);
                }
                else if (temperate >= _warningLevel)
                {
                    _hasReachedWarningTemperature = true;
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temperate,
                        CurrentDateTime = DateTime.Now
                    };
                    OnTemperatureReachesWarningLevel(e);
                }
                else if (_hasReachedWarningTemperature && temperate < _warningLevel)
                {
                    _hasReachedWarningTemperature = false;
                    TemperatureEventArgs e = new TemperatureEventArgs
                    {
                        Temperature = temperate,
                        CurrentDateTime = DateTime.Now
                    };
                    OnTemperatureFallsBelowWarningLevel(e);
                }

                Thread.Sleep(1000);
            }
        }

        private void SeedData()
        {
            _temperateData = [16, 17, 16.5, 18, 19, 22, 24, 26.75, 28.7, 27.6, 26, 24, 22, 45, 68, 86.45];
        }

        protected void OnTemperatureReachesEmergencyLevel(TemperatureEventArgs e)
        {
            var handler = (EventHandler<TemperatureEventArgs>?)_listEventDelegates[_temperatureReachesEmergencyLevelKey];
            handler?.Invoke(this, e);
        }

        protected void OnTemperatureFallsBelowWarningLevel(TemperatureEventArgs e)
        {
            var handler = (EventHandler<TemperatureEventArgs>?)_listEventDelegates[_temperatureFallsBelowWarningLevelKey];
            handler?.Invoke(this, e);
        }

        protected void OnTemperatureReachesWarningLevel(TemperatureEventArgs e)
        {
            var handler = (EventHandler<TemperatureEventArgs>?)_listEventDelegates[_temperatureReachesWarningLevelKey];
            handler?.Invoke(this, e);
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesEmergencyLevelEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureReachesEmergencyLevelKey, value);
            }

            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureReachesEmergencyLevelKey, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureReachesWarningLevelEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureReachesWarningLevelKey, value);
            }

            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureReachesWarningLevelKey, value);
            }
        }

        event EventHandler<TemperatureEventArgs> IHeatSensor.TemperatureFallsBelowWarningLevelEventHandler
        {
            add
            {
                _listEventDelegates.AddHandler(_temperatureFallsBelowWarningLevelKey, value);
            }

            remove
            {
                _listEventDelegates.RemoveHandler(_temperatureFallsBelowWarningLevelKey, value);
            }
        }

        public void RunHeatSensor()
        {
            Console.WriteLine("Heat sensor is running");
            MonitorTemperature();
        }
    }

    public interface IHeatSensor
    {
        event EventHandler<TemperatureEventArgs> TemperatureReachesEmergencyLevelEventHandler;

        event EventHandler<TemperatureEventArgs> TemperatureReachesWarningLevelEventHandler;

        event EventHandler<TemperatureEventArgs> TemperatureFallsBelowWarningLevelEventHandler;

        void RunHeatSensor();
    }

    public class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; set; }
        public DateTime CurrentDateTime { get; set; }
    }
}