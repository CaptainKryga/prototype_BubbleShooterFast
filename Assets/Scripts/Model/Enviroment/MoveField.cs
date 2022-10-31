using System;
using UnityEngine;

namespace Model
{
    public class MoveField : MonoBehaviour
    {
        private void Update()
        {
            transform.position += Vector3.down * Time.deltaTime;
        }
    }
}
