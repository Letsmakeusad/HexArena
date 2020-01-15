using Assets.Scripts.PowerUpScripts.RunTimeSpawnSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjectsScripts
{
    public class PowerUp: Thing
    {
        public Ability effect;


        void OnTriggerEnter(Collider collider)
        {
            if (collider.CompareTag("Player"))
            {
 
               effect.TriggerAbility(collider.gameObject);
               this.gameObject.SetActive(false);
            }
        }
    }
}
