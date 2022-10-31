using UnityEngine;

namespace Utils
{
    public class QSetings : MonoBehaviour
    {
        void Start()
        {
            QualitySettings.maxQueuedFrames = 60;
            QualitySettings.vSyncCount = 1;
        }
    }
}
