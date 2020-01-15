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
    [CreateAssetMenu(fileName = "FireBall", menuName = "Spells/Damaging/FireBall")]
    public class FireBallEffect : Ability
    {
        public GameObject FireBallPrefabModel;

        public override void TriggerAbility(GameObject target)
        {
            Instantiate(FireBallPrefabModel,target.transform.position, target.transform.rotation);
        }

         
    }
}
