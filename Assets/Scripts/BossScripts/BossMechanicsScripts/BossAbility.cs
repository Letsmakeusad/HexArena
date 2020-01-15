namespace Assets.Scripts.BossScripts.BossMechanicsScripts
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using UnityEngine;

    
    public class BossAbility: MonoBehaviour
    {

        public GameObject AbilityGroundIndicator;
        public GameObject AbilityPrefab;
        public Animator IndicatorAnimator;
        

        public float TimeToSpawn;

        public void ActivateIndicator(Transform target)
        {
            this.IndicatorAnimator.speed /= TimeToSpawn;
            AbilityGroundIndicator.SetActive(true);
            
        }

        public void DeactivateIndicator()
        {
            this.IndicatorAnimator.speed = 1;
            AbilityGroundIndicator.SetActive(false);
            
        }
          
        public void SpawnAbility(Transform target)
        {
            if (this.gameObject.activeSelf)
                Instantiate(AbilityPrefab, target);
        }


        IEnumerator StartAbilityCoroutine(Transform target)
        {
            
           
            ActivateIndicator(target);
            var time = TimeToSpawn;
            while (time >= 0)
            {
                
                time -= Time.deltaTime;
                yield return null;

            }
            DeactivateIndicator();
            SpawnAbility(target);
            


        }

        public void StartAbility(Transform target)
        {
            
            if (this.gameObject.activeSelf)
            {
                
                StartCoroutine(StartAbilityCoroutine(target));
            }
           
        }

        public void OnDisable()
        {
            DeactivateIndicator();
        }
    }
}
