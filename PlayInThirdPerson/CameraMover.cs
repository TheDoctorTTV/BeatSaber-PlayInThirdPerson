using UnityEngine;

namespace PlayInThirdPerson
{
    public class CameraMover : MonoBehaviour
    {
        private Vector3 CameraOffset => ConfigHelper.Config.Offset;

        private void LateUpdate()
        {
            // Continuously update the camera's position
            if (Plugin.IsEnabled)
            {
                transform.localPosition = CameraOffset;
            }
            else
            {
                transform.localPosition = Vector3.zero;
            }
        }

        // Called explicitly when the configuration is updated
        public void UpdateCameraPosition()
        {
            if (Plugin.IsEnabled)
            {
                transform.localPosition = CameraOffset;
            }
            else
            {
                transform.localPosition = Vector3.zero;
            }

            Debug.Log($"[PlayInThirdPerson] Camera position updated to: {transform.localPosition}");
        }
    }
}
