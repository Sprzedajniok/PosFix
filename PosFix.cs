using IPA;
using IPA.Config;
using IPA.Config.Stores;
using PosFix.Configuration;
using BeatSaberMarkupLanguage.Settings;
using UnityEngine;
using IPALogger = IPA.Logging.Logger;
using BS_Utils.Utilities;

namespace PosFix
{
    public static class PosFix
    {
        internal static IPALogger Log { get; set; }
            public static void Setup()
        {
            BSEvents.gameSceneActive += SongStart;
            BSEvents.menuSceneActive += SongExit;
        }
        private static void SongStart()
        {
            // DO MAGIC HERE THAT IT WILL WORK
            Logger.Log.Info("TESTING START");
        }
        private static void SongExit()
        {
            // DO MAGIC HERE THAT IT WILL WORK THERE TOO
            Logger.Log.Info("TESTING EXIT");
        }
    }
}