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
        public OVRResetOrientation _resetPos;

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
            //Okay so this little piece of shit throws some errors?
            // -->   PosFix.Setup();
            // BS_Utils] Caught Exception when executing event: Exception has been thrown by the target of an invocation.
            // [ERROR @ 22:18:22 | BS_Utils]  In Assembly: PosFix, Version = 0.0.1.0, Culture = neutral, PublicKeyToken = null
            //
            Log.Info("dupa");
        }

        //Dunno, just copied that ovrrresetorientation 
        private void Update()
        {
            if (OVRInput.GetDown(_resetPos.resetButton))
            {
                OVRManager.display.RecenterPose();
                Log.Info("test");
                //FIRST CRITICAL ERROR POGGERS
                //BUT AT LEAST I KNOW SOMETHING HAPPENS WHEN BUTTON IS PRESSED WOHOOO
                // [CRITICAL @ 22:27:26 | UnityEngine] NullReferenceException: Object reference not set to an instance of an object
                // [CRITICAL @ 22:27:26 | UnityEngine] OVRResetOrientation.Update()(at < 56fd09ffbe204ba5b452536e1c7b2566 >:0)

            }
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

