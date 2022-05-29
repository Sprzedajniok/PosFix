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
        public static void Setup()
        {
            BSEvents.gameSceneActive += SongStart;
            BSEvents.menuSceneActive += SongExit;
        }
        private static void SongStart()
        {
            // DO MAGIC HERE THAT IT WILL WORK
        }
        private static void SongExit()
        {
            // DO MAGIC HERE THAT IT WILL WORK THERE TOO
        }
    }
}