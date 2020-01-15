using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PowerUpScripts
{
    //TO DO: OPTIMIZE THIS TO USE RUNTIME TARGET!!!
    public class Projectile: MonoBehaviour
    {
        /// <summary>
        /// The base movement speed of the missile, in units per second. 
        /// </summary>
        [SerializeField]
        private float speed = 15;

        /// <summary>
        /// The base rotation speed of the missile, in radians per second. 
        /// </summary>
        [SerializeField]
        private float rotationSpeed = 1000;

        /// <summary>
        /// The distance at which this object stops following its target and continues on its last known trajectory. 
        /// </summary>
        [SerializeField]
        private float focusDistance = 5;

        /// <summary>
        /// The transform of the target object.
        /// </summary>
        [Header("Target")]
        public Transform target;

        /// <summary>
        /// Returns true if the object should be looking at the target. 
        /// </summary>
        private bool isLookingAtObject = true;

        public bool hasTarget;

        /// <summary>
        /// The tag of the target object.
        /// </summary>
        [SerializeField]
        private string targetTag;

        /// <summary>
        /// Error message.
        /// </summary>
        [Header("TIP")]
        private string enterTagPls = "Please enter the tag of the object you'd like to target, in the field 'Target Tag' in the Inspector.";

        private void Start()
        {
            if (!hasTarget)
            {
                target = this.transform;
            }
            else
            {
                hasTarget = true;
                target = GameObject.FindGameObjectWithTag(targetTag).transform;
            }
            
        }

        private void  Update()
        {
            if (hasTarget)
            {
                MoveTowardsTarget();
            }
            else if (!hasTarget)
            {
                MoveForward();
            }
           
        }


        private void MoveTowardsTarget()
        {
            Vector3 targetDirection = target.position - transform.position;

            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

            if (Vector3.Distance(transform.position, target.position) < focusDistance)
            {
                isLookingAtObject = false;
            }

            if (isLookingAtObject)
            {
                transform.rotation = Quaternion.LookRotation(newDirection);
            }
        }

        private void MoveForward()
        {
            //Vector3 targetDirection = target.position - transform.position;

            //Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, rotationSpeed * Time.deltaTime, 0.0F);

            transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.Self);

            //if (Vector3.Distance(transform.position, target.position) < focusDistance)
            //{
            //    isLookingAtObject = false;
            //}

            //if (isLookingAtObject)
            //{
            //    transform.rotation = Quaternion.LookRotation(newDirection);
            //}
        }
    }
}
