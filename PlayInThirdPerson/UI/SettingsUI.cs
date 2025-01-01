using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.GameplaySetup;
using UnityEngine;

namespace PlayInThirdPerson.UI
{
    public class SettingsUI
    {
        private static SettingsUI _instance;
        public static SettingsUI Instance => _instance ??= new SettingsUI();

        private Config _tempConfig = new Config(ConfigHelper.Config);

        [UIValue("boolEnable")]
        public bool Enabled
        {
            get => _tempConfig.Enabled;
            set => _tempConfig.Enabled = value;
        }

        [UIValue("cameraOffsetY")]
        public float CameraOffsetY
        {
            get => _tempConfig.Offset.Y;
            set => _tempConfig.Offset.Y = value;
        }

        [UIValue("cameraOffsetZ")]
        public float CameraOffsetZ
        {
            get => _tempConfig.Offset.Z;
            set => _tempConfig.Offset.Z = value;
        }

        [UIAction("apply")]
        public void OnApply()
        {
            Debug.Log("[PlayInThirdPerson] OnApply called.");
            ConfigHelper.SaveNewConfig(_tempConfig);
        }

        [UIAction("ok")]
        public void OnOk()
        {
            Debug.Log("[PlayInThirdPerson] OnOk called.");
            ConfigHelper.SaveNewConfig(_tempConfig);
        }

        public void Initialize()
        {
            Debug.Log("[PlayInThirdPerson] Initializing SettingsUI.");
            GameplaySetup.Instance.AddTab(
                "Third Person",
                "PlayInThirdPerson.UI.SettingsUI.bsml",
                this
            );
        }

        public void Dispose()
        {
            Debug.Log("[PlayInThirdPerson] Disposing SettingsUI.");
            GameplaySetup.Instance.RemoveTab("Third Person");
        }
    }
}
