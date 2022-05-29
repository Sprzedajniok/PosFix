using IPA;
using IPA.Config;
using IPA.Config.Stores;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PosFix.Configuration;
using BeatSaberMarkupLanguage.Settings;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
using IPALogger = IPA.Logging.Logger;

namespace PosFix
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        internal static Plugin Instance { get; private set; }
        internal static IPALogger Log { get; private set; }
        private OVRResetOrientation _resetPos;

        [Init]
        /// <summary>
        /// Called when the plugin is first loaded by IPA (either when the game starts or when the plugin is enabled if it starts disabled).
        /// [Init] methods that use a Constructor or called before regular methods like InitWithConfig.
        /// Only use [Init] with one Constructor.
        /// </summary>
        public void Init(Config config, IPALogger logger)
        {
            Instance = this;
            Log = logger;
            Log.Info("PosFix initialized.");

            PluginConfig.Instance = config.Generated<PluginConfig>();
            BSMLSettings.instance.AddSettingsMenu("PosFix", "PosFix.Views.Settings.bsml", Configuration.PluginConfig.Instance);
        }

        #region BSIPA Config
        //Uncomment to use BSIPA's config
        /*
        [Init]
        public void InitWithConfig(Config conf)
        {
            Configuration.PluginConfig.Instance = conf.Generated<Configuration.PluginConfig>();
            Log.Debug("Config loaded");
        }
        */
        #endregion

        [OnStart]
        public void OnApplicationStart()
        {

            _resetPos = new GameObject("SprzedajniokowyResetowacz").AddComponent<OVRResetOrientation>();
            _resetPos.resetButton = OVRInput.RawButton.X;
        }

            [OnExit]
        public void OnApplicationQuit()
        {

        }
    }
}
