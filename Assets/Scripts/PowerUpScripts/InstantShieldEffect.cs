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
    [CreateAssetMenu(fileName = "InstantHeal", menuName = "Spells/Shielding/InstantShield")]
    public class InstantShieldEffect: Ability
    {
        public float ShieldAmount;
        public GameObject particleEffect;
        public override void TriggerAbility(GameObject target)
        {
            if (target.gameObject != null)
            {
                target.GetComponent<UnitHealthController>().Shield(ShieldAmount);
                 Instantiate(particleEffect, target.transform);
            }
               
              
        }
    }


}
