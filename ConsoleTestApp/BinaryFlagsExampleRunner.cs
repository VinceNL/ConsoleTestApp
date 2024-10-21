namespace ConsoleTestApp
{
    public static class BinaryFlagsExampleRunner
    {
        public static void Run()
        {
            // Combine multiple permissions using bitwise OR operator
            SystemPermissions permissions = SystemPermissions.Read | SystemPermissions.Write | SystemPermissions.Move;

            // Add the Delete permission
            permissions |= SystemPermissions.Delete;

            Console.WriteLine($"Permissions: {ConvertToBinary((int)permissions)}");
            Console.WriteLine();

            // Iterate over all enum values and check each permission
            foreach (SystemPermissions permission in Enum.GetValues(typeof(SystemPermissions)))
            {
                // Skip the None value
                if (permission != SystemPermissions.None)
                {
                    CheckPermission(permissions, permission);
                }
            }

            Console.WriteLine();

            // Remove the Write and Move permissions
            permissions = RemovePermission(permissions, SystemPermissions.Write);
            permissions = RemovePermission(permissions, SystemPermissions.Move);

            Console.WriteLine();
            Console.WriteLine($"Permissions after removal: {ConvertToBinary((int)permissions)}");
            Console.WriteLine();
        }

        private static string ConvertToBinary(int value, int places = 8)
        {
            return Convert.ToString(value, 2).PadLeft(places, '0');
        }

        private static void CheckPermission(SystemPermissions permissions, SystemPermissions permissionToCheck)
        {
            // Check if a permission is set using bitwise AND operator
            if ((permissions & permissionToCheck) == permissionToCheck)
            {
                Console.WriteLine($"Permission {permissionToCheck} is set.");
            }
            else
            {
                Console.WriteLine($"Permission {permissionToCheck} is NOT set.");
            }
        }

        private static SystemPermissions RemovePermission(SystemPermissions permissions, SystemPermissions permissionToRemove)
        {
            Console.WriteLine($"Removing permission {permissionToRemove}...");

            // Remove a permission using bitwise AND and NOT operators
            return permissions & ~permissionToRemove;
        }

        // Define an enumeration with the [Flags] attribute to indicate bit fields
        [Flags]
        private enum SystemPermissions
        {
            None = 0,        //
            Read = 1,        // (binary 00000001)
            Write = 2,       // (binary 00000010)
            Execute = 4,     // (binary 00000100)
            Delete = 8,      // (binary 00001000)
            Modify = 16,     // (binary 00010000)
            Copy = 32,       // (binary 00100000)
            Move = 64,       // (binary 01000000)
            Rename = 128,    // (binary 10000000)
            Create = 256,    // (binary 100000000)
            All = Read | Write | Execute | Delete | Modify | Copy | Move | Rename | Create // All permissions combined
        }
    }
}