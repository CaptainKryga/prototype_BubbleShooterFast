using UnityEngine;

namespace Utils
{
    public class QSetings : MonoBehaviour
    {
        void Awake()
        {
            QualitySettings.maxQueuedFrames = 60;
            QualitySettings.vSyncCount = 1;
        }
    }
}
