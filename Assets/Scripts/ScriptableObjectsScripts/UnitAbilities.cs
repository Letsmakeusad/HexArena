using Assets.Scripts.TestScript.Variables;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjectsScripts
{
    public class UnitAbilities: MonoBehaviour
    {
        public List<Ability> abilities;
        public GameObject AbilityHolder;

        public GameObject PlayerReference;
        [Header("Spell Instantiate Point")]
        public GameObject RightHand;

        void Awake()
        {
            GetAbilities(AbilityHolder);
        }


        public void TriggerUnitAbility(float delay,int abilityId)
        {
            // StartCoroutine(CastAbilityWithDelay(delay, abilityId));
            CastAbilityWithDelay(abilityId);
        }

        public void  CastAbilityWithDelay(int abilityId)
        {

            var spell = this.abilities.Where(x => x.AbilityID == abilityId).FirstOrDefault();
 
            if (!spell.TargetSelf)
                spell.TriggerAbility(RightHand);
            else
            {
                spell.TriggerAbility(PlayerReference);
            }

        }

        //IEnumerator CastAbilityWithDelay(float delay,int abilityId)
        //{

        //    var spell = this.abilities.Where(x => x.AbilityID == abilityId).FirstOrDefault();
        //    var time = delay;
        //    while (time >= 0)
        //    {

        //        time -= Time.deltaTime;
        //        yield return null;

        //    }



        //    if (!spell.TargetSelf)
        //        spell.TriggerAbility(RightHand);
        //    else
        //    {
        //        spell.TriggerAbility(PlayerReference);
        //    }

        //}


        public void GetAbilities(GameObject spellList)
        {
            var spells = spellList.GetComponentsInChildren<AbilityCooldown>();
            foreach (var spell in spells)
            {
                this.abilities.Add(spell.ability);
            }
        }
        

    }
}
