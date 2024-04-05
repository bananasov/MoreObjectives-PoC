using BepInEx;
using BepInEx.Logging;
using System.Collections.Generic;
using MonoMod.RuntimeDetour;
using MoreObjectives.Hooks;

namespace MoreObjectives;

[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class MoreObjectives : BaseUnityPlugin
{
    public static MoreObjectives Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger { get; private set; } = null!;

    private void Awake()
    {
        Logger = base.Logger;
        Instance = this;
        
        Hook();

        Logger.LogInfo($"{MyPluginInfo.PLUGIN_GUID} v{MyPluginInfo.PLUGIN_VERSION} has loaded!");
    }

    private static void Hook()
    {
        Logger.LogDebug("Hooking...");

        ObjectiveDatabasePatches.Init();

        Logger.LogDebug("Finished Hooking!");
    }
}