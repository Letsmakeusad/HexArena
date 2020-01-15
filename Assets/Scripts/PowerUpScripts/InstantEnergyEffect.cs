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
    [CreateAssetMenu(fileName = "InstantHeal", menuName = "Spells/Energizing/InstantHeal")]
    public class InstantEnergyEffect : Ability
    {

        
        public GameObject particleEffect;
        public int EnergyGainAmount;
        public override void TriggerAbility(GameObject target)
        {
            if (target.gameObject != null)
            {
                target.GetComponent<UnitHealthController>().Energize(EnergyGainAmount);                     
                Instantiate(particleEffect, target.transform);
            }

        }
    }
}
