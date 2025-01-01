using BeatSaberMarkupLanguage.Attributes;
using BeatSaberMarkupLanguage.ViewControllers;

namespace PlayInThirdPerson.UI
{
    [HotReload] // Enables hot-reloading for debugging purposes
    [ViewDefinition("PlayInThirdPerson.UI.SettingsUI.bsml")] // Path to the BSML file
    public class SettingsUIController : BSMLAutomaticViewController
    {
        // Toggle for enabling/disabling third-person mode
        [UIValue("boolEnable")]
        public bool EnableThirdPerson
        {
            get => ConfigHelper.Config.Enabled; // Load the value from the config
            set
            {
                ConfigHelper.Config.Enabled = value; // Save the value to the config
                ConfigHelper.SaveNewConfig(ConfigHelper.Config);
            }
        }

        // Property for adjusting the Y-axis offset
        [UIValue("cameraOffsetY")]
        public float CameraOffsetY
        {
            get => ConfigHelper.Config.Offset.Y; // Load the value from the config
            set
            {
                ConfigHelper.Config.Offset.Y = value; // Save the value to the config
                ConfigHelper.SaveNewConfig(ConfigHelper.Config);
            }
        }

        // Property for adjusting the X-axis offset
        [UIValue("cameraOffsetX")]
        public float CameraOffsetX
        {
            get => ConfigHelper.Config.Offset.X; // Load the value from the config
            set
            {
                ConfigHelper.Config.Offset.X = value; // Save the value to the config
                ConfigHelper.SaveNewConfig(ConfigHelper.Config);
            }
        }

        // Property for adjusting the Z-axis offset
        [UIValue("cameraOffsetZ")]
        public float CameraOffsetZ
        {
            get => ConfigHelper.Config.Offset.Z; // Load the value from the config
            set
            {
                ConfigHelper.Config.Offset.Z = value; // Save the value to the config
                ConfigHelper.SaveNewConfig(ConfigHelper.Config);
            }
        }

        // Button action to apply changes
        [UIAction("apply")]
        private void ApplyChanges()
        {
            ConfigHelper.SaveNewConfig(ConfigHelper.Config); // Save all changes
        }
    }
}
