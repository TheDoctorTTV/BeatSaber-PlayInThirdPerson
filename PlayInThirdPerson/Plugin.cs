using BeatSaberMarkupLanguage.GameplaySetup;
using HarmonyLib;
using IPA;
using IPA.Logging;
using BS_Utils.Utilities;
using PlayInThirdPerson.UI;
using Zenject;
using System;
using System.Reflection;

namespace PlayInThirdPerson
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public static Logger Logger { get; private set; }

        // Convenience property for enabling/disabling third-person mode
        public static bool IsEnabled => ConfigHelper.Config.Enabled;

        private readonly Harmony _harmony = new Harmony("com.Nicky.BeatSaber.PlayInThirdPerson");

        [Init]
        public void Init(Logger logger)
        {
            Logger = logger;
            ConfigHelper.LoadConfig();
        }

        [OnStart]
        public void OnApplicationStart()
        {
            try
            {
                _harmony.PatchAll(Assembly.GetExecutingAssembly());
                BS_Utils.Utilities.BSEvents.menuSceneLoadedFresh += AddGameplayTab;

                Logger.Info("PlayInThirdPerson mod initialized successfully.");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error initializing PlayInThirdPerson mod: {ex.Message}");
            }
        }

        private void AddGameplayTab()
        {
            try
            {
                GameplaySetup.Instance.AddTab(
                    "Third Person",
                    "PlayInThirdPerson.UI.SettingsUI.bsml",
                    new SettingsUIController()
                );

                Logger.Info("Settings tab added successfully.");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error adding settings tab: {ex.Message}");
            }
        }

        [OnExit]
        public void OnApplicationQuit()
        {
            try
            {
                _harmony.UnpatchSelf();

                if (GameplaySetup.Instance != null)
                {
                    GameplaySetup.Instance.RemoveTab("Third Person");
                }

                Logger.Info("PlayInThirdPerson mod shut down successfully.");
            }
            catch (Exception ex)
            {
                Logger.Error($"Error shutting down PlayInThirdPerson mod: {ex.Message}");
            }
        }
    }
}
