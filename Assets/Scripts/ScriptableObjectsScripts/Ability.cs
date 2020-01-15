using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjectsScripts
{
   
   public abstract class Ability: ScriptableObject
    {
        public string Name;
        public int AbilityID;
        public Sprite AbilityIcon;
        public AudioClip AbilitySound;
        public float baseCooldown = 1f;
        public float energyCost = 1f;
        public bool TargetSelf = false;
 
        public abstract void TriggerAbility(GameObject target);
         
 
    }
}
