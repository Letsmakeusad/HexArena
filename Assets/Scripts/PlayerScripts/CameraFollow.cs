using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.EditorScripts
{
    public class CameraFollow: MonoBehaviour
    {
        public Transform target;

        public float smoothSpeed;

        public Vector3 cameraOffset;

        void FixedUpdate()
        {
            Vector3 desiredPosition = target.position + cameraOffset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
