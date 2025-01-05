using BeatSaberMarkupLanguage.GameplaySetup;
using HarmonyLib;
using IPA;
using BS_Utils.Utilities;
using PlayInThirdPerson.UI;
using Zenject;
using System.Reflection;
using UnityEngine;

namespace PlayInThirdPerson
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public static bool IsEnabled => ConfigHelper.Config.Enabled;

        private readonly Harmony _harmony = new Harmony("com.Nicky.BeatSaber.PlayInThirdPerson");

        [Init]
        public void Init()
        {
            ConfigHelper.LoadConfig();
        }

        [OnStart]
        public void OnApplicationStart()
        {
            try
            {
                _harmony.PatchAll(Assembly.GetExecutingAssembly());
                BS_Utils.Utilities.BSEvents.menuSceneLoadedFresh += AddGameplayTab;
                BS_Utils.Utilities.BSEvents.gameSceneLoaded += GameSceneLoaded;
            }
            catch { }
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
            }
            catch { }
        }

        private void GameSceneLoaded()
        {
            try
            {
                SetupCamera();
            }
            catch { }
        }

        private void SetupCamera()
        {
            try
            {
                // Find the main camera
                Transform mainCamera = Camera.main?.transform;

                if (mainCamera == null)
                {
                    return;
                }

                // Create and attach Camera Mover
                Transform cameraMover = new GameObject("Camera Mover").transform;
                cameraMover.SetParent(mainCamera.parent, false);
                cameraMover.gameObject.AddComponent<CameraMover>();

                // Reparent the main camera
                mainCamera.SetParent(cameraMover, true);
            }
            catch { }
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
            }
            catch { }
        }
    }
}
