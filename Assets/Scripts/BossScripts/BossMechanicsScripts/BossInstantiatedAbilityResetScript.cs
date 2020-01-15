using Assets.Scripts.TestScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BossScripts.BossMechanicsScripts
{
    public class BossInstantiatedAbilityResetScript: MonoBehaviour
    {

        public GameEvent ResetBossCastCooldown;
        

        public void ResetCastCooldown()
        {
            ResetBossCastCooldown.Raise();
        }

        public void DestroyAbility()
        {
            Destroy(this.gameObject);
        }

        void OnDisable()
        {
            Destroy(this.gameObject);
        }

    }
}
