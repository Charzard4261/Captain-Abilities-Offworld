using BepInEx;
using MonoMod.RuntimeDetour;
using R2API.Utils;
using RoR2;
using RoR2.Skills;

namespace CaptainAbilitiesOffworld
{
    [BepInDependency(R2API.R2API.PluginGUID)]
	
	//This attribute is required, and lists metadata for your plugin.
    [BepInPlugin(PluginGUID, PluginName, PluginVersion)]
	
    public class CaptainAbilitiesOffworld : BaseUnityPlugin
	{
        public const string PluginGUID = PluginAuthor + "." + PluginName;
        public const string PluginAuthor = "Charzard4261";
        public const string PluginName = "CaptainAbilitiesOffworld";
        public const string PluginVersion = "1.0.0";
        Hook Hook;

        public void Awake()
        {
            Hook = new Hook(
                typeof(CaptainOrbitalSkillDef).GetMethodCached("get_isAvailable"),
                typeof(CaptainAbilitiesOffworld).GetMethodCached(nameof(OrbitalSkillsHook))
                );
        }

        private static bool OrbitalSkillsHook(CaptainOrbitalSkillDef self)
        {
            return true;
        }
    }
}
