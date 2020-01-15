using Assets.Scripts.ScriptableObjectsScripts;
using Assets.Scripts.TestScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PowerUpScripts
{
    [CreateAssetMenu(fileName = "InstantHeal", menuName ="Spells/Healing/InstantHeal")]
    public class InstantHealEffect : Ability
    {
        
        public float healAmount;
        public GameObject particleEffect;
        public override void TriggerAbility(GameObject target)
        {
            if (target.gameObject != null)
            {
                target.GetComponent<UnitHealthController>().Heal(healAmount);
                Instantiate(particleEffect, target.transform);
            }
                
        }
    }
}
