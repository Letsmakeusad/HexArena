using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BossScripts.BossMechanicsScripts
{
    public class SimpleRotationAroundYAxis: MonoBehaviour
    {
        public float rotationSpeed;



       void FixedUpdate()
        {
            this.transform.RotateAround(transform.position, transform.up, Time.deltaTime * rotationSpeed);
        }
    }
}
