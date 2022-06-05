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
        public OVRResetOrientation _resetPos = new OVRResetOrientation();

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
            PosFix.Setup();
            // BS_Utils] Caught Exception when executing event: Exception has been thrown by the target of an invocation.
            // [ERROR @ 22:18:22 | BS_Utils]  In Assembly: PosFix, Version = 0.0.1.0, Culture = neutral, PublicKeyToken = null
            //
            Log.Info("dupa");
        }

        //Dunno, just copied that ovrrresetorientation 
        public void Update()
        {
            if (OVRInput.GetDown(_resetPos.resetButton))
            {
                OVRManager.display.RecenterPose();
                Log.Info("test");
                //FIRST CRITICAL ERROR POGGERS
                //BUT AT LEAST I KNOW SOMETHING HAPPENS WHEN BUTTON IS PRESSED WOHOOO
                // [CRITICAL @ 22:27:26 | UnityEngine] NullReferenceException: Object reference not set to an instance of an object
                // [CRITICAL @ 22:27:26 | UnityEngine] OVRResetOrientation.Update()(at < 56fd09ffbe204ba5b452536e1c7b2566 >:0)
                
                // NOTE TO MYSELF
                // using OVRManager.display.RecenterPose(); 
                // [ERROR @ 18:05:54 | IPA] PosFix OnEnable: System.NullReferenceException: Object reference not set to an instance of an object
                // [ERROR @ 18:05:54 | IPA]   at PosFix.Plugin.OnApplicationStart()[0x00006] in < 9cc4bb8efaa84bcba18da5ad5da1334e >:0
                // [ERROR @ 18:05:54 | IPA]   at(wrapper dynamic - method) System.Object.lambda_method(System.Runtime.CompilerServices.Closure, object)
                // [ERROR @ 18:05:54 | IPA]   at IPA.Loader.PluginExecutor.Enable()[0x0000c] in < 85e5e5773585418d89fcc2712ee48bcc >:0
                // [ERROR @ 18:05:54 | IPA]   at IPA.Loader.Composite.CompositeBSPlugin +<> c.< OnEnable > b__4_0(IPA.Loader.PluginExecutor plugin)[0x00000] in < 85e5e5773585418d89fcc2712ee48bcc >:0
                // [ERROR @ 18:05:54 | IPA]   at IPA.Loader.Composite.CompositeBSPlugin.Invoke(IPA.Loader.Composite.CompositeBSPlugin + CompositeCall callback, System.String method)[0x00018] in < 85e5e5773585418d89fcc2712ee48bcc >:0

            }
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            //Same stuff as before ffs
            Log.Info("dupa");
        }
    }
}

