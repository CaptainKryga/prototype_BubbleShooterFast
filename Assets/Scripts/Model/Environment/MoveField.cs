using UnityEngine;

namespace Model.Environment
{
    public class MoveField : MonoBehaviour
    {
        private void Update()
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
    }
}
