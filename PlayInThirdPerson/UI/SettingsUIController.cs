using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;

namespace PlayInThirdPerson.UI
{
    [HotReload]
    [ViewDefinition("PlayInThirdPerson.UI.SettingsUI.bsml")]
    public class SettingsUIController : BSMLAutomaticViewController
    {
        // Enable or disable third-person mode
        [UIValue("boolEnable")]
        public bool EnableThirdPerson
        {
            get => ConfigHelper.Config.Enabled;
            set
            {
                ConfigHelper.Config.Enabled = value;
                ConfigHelper.SaveConfig();
            }
        }

        // Slider for Camera Offset Y
        [UIValue("cameraOffsetY")]
        public float CameraOffsetY
        {
            get => ConfigHelper.Config.Offset.Y;
            set
            {
                ConfigHelper.Config.Offset.Y = value;
                ConfigHelper.SaveConfig();
            }
        }

        // Slider for Camera Offset Z
        [UIValue("cameraOffsetZ")]
        public float CameraOffsetZ
        {
            get => ConfigHelper.Config.Offset.Z;
            set
            {
                ConfigHelper.Config.Offset.Z = value;
                ConfigHelper.SaveConfig();
            }
        }

        // Apply button action
        [UIAction("apply")]
        private void ApplyChanges()
        {
            ConfigHelper.SaveConfig();
        }
    }
}
