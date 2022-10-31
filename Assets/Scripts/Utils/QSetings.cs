using UnityEngine;

namespace Utils
{
    public class QSetings : MonoBehaviour
    {
        void Awake()
        {
            QualitySettings.vSyncCount = 1;
            Application.targetFrameRate = 60;
        }
    }
}
