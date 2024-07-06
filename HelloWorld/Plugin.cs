using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using MGSC;

namespace HelloWorld
{
    [BepInPlugin(PluginGuid, PluginName, PluginVersion)]
    public class Plugin : BaseUnityPlugin
    {
        public const string PluginGuid = "example.HelloWorld";
        public const string PluginName = "Hello World";
        public const string PluginVersion = "1.0.0";

        public static Plugin Instance { get; private set; }
        public static ManualLogSource Logger { get; private set; }

        private void Awake()
        {
            // Plugin startup logic
            Instance = this;
            Logger = base.Logger;
            Logger.LogInfo($"Plugin '{PluginGuid}' is loaded!");

            // Patch all Harmony patches
            var harmony = new Harmony(PluginGuid);
            harmony.PatchAll();
        }
    }

    [HarmonyPatch(typeof(Bootstrap), "LogSystemInfo")]
    public static class Bootstrap_LogSystemInfo_Patch
    {
        public static void Postfix()
        {
            Plugin.Logger.LogInfo("Hello World!");
        }
    }
}
