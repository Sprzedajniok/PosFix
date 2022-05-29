using PosFix;
using IPA;
using IPA.Config;
using IPA.Config.Stores;
using PosFix.Configuration;
using BeatSaberMarkupLanguage.Settings;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;

namespace PosFix
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; set; }
        internal static IPALogger Log { get; set; }
        private OVRResetOrientation _resetPos;

        [Init]
        public void Init(Config config, IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("PosFix initialized.");

            PluginConfig.Instance = config.Generated<PluginConfig>();
            BSMLSettings.instance.AddSettingsMenu("PosFix", "PosFix.Views.Settings.bsml", Configuration.PluginConfig.Instance);
        }

        [OnStart]
        public void OnApplicationStart()
        {
            //Reset posistion on startup, it should do it automatically without user needing to press button, BUT EVEN THAT DOESNT WORK HELP ME
            _resetPos = new GameObject("resetPos").AddComponent<OVRResetOrientation>();
            _resetPos.resetButton = OVRInput.RawButton.X;
            GameObject.DontDestroyOnLoad(_resetPos);
            Log.Info("Posistion reset on startup");
            //is this even good? Anything happens?
            PosFix.Setup();
            Log.Info("dupa");
        }

            [OnExit]
        public void OnApplicationQuit()
        {
            //Same stuff as before ffs
            _resetPos = new GameObject("resetPos").AddComponent<OVRResetOrientation>();
            _resetPos.resetButton = OVRInput.RawButton.X;
            GameObject.DontDestroyOnLoad(_resetPos);
            Log.Info("Posistion reset on game exit");
        }
    }
}
