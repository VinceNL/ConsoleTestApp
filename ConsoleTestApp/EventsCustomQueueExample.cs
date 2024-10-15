using WarehouseManagementSystemAPI;

namespace EventsCustomQueueExample
{
    public abstract class HardwareItem : IEntityPrimaryProperties, IEntityAdditionalProperties
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }

    public interface IDrill
    {
        string DrillBrandName { get; set; }
    }

    public class Drill : HardwareItem, IDrill
    {
        public string DrillBrandName { get; set; } = string.Empty;
    }

    public interface ILadder
    {
        string LadderBrandName { get; set; }
    }

    public class Ladder : HardwareItem, ILadder
    {
        public string LadderBrandName { get; set; } = string.Empty;
    }

    public interface iHammer
    {
        string HammerBrandName { get; set; }
    }

    public class Hammer : HardwareItem, iHammer
    {
        public string HammerBrandName { get; set; } = string.Empty;
    }

    public interface IPaintBrush
    {
        string PaintBrushBrandName { get; set; }
    }

    public class PaintBrush : HardwareItem, IPaintBrush
    {
        public string PaintBrushBrandName { get; set; } = string.Empty;
    }
}