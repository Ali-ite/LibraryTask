using LibraryTask.Debugging;

namespace LibraryTask
{
    public class LibraryTaskConsts
    {
        public const string LocalizationSourceName = "LibraryTask";
        public const string AppServerRootAddressKey = "App:ServerRootAddress";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "49706e859fe141899eb86a2b589eb9af";
    }
}
