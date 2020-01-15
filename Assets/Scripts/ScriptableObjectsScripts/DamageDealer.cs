using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.TestScript.Variables
{
    [CreateAssetMenu(fileName = "Damage Dealer Component", menuName = "DamageDealer Component")]
    public class DamageDealer : MonoBehaviour
    {
        public FloatReference DamageAmount;
        public ElementReference ElementType;
        public GameObject particleEffect;
        public GameEvent OnTargetHitEvent;
        public bool TargetPlayer;
        public bool TargetBoss;
        public bool TargetWall;

        public bool DestroyOnHit;
        public bool ShakeCameraOnHit;




        void Start()
        {


        }


        void OnTriggerEnter(Collider other)
        {

 
            if ((other.CompareTag("Player") && TargetPlayer) || (other.CompareTag("Boss") && TargetBoss))
            {
                
                if (this.OnTargetHitEvent != null)
                {
                    OnTargetHitEvent.Raise();
                }
               
 
                var healthController = other.gameObject.GetComponent<UnitHealthController>();
                if (healthController != null)
                {
                 
                    //  Debug.Log($"Damage after resists {UnitResistances.CalculateDamageWithResistance(damage.DamageAmount, damage.ElementType)} ");
                    healthController.TakeDamage(DamageAmount.Value, ElementType.Value);
                    if(particleEffect!= null)
                    {
                        Instantiate(particleEffect, other.transform);
                    }
                   
                    if (DestroyOnHit)
                    {
                        if (particleEffect != null)
                        {
                            Instantiate(particleEffect, other.transform);
                        }
                       
                        Destroy(this.gameObject, 0.2f);
                    }
                  
                }
                
            }
            else if (other.CompareTag("Wall") && TargetWall)
            {
                if (DestroyOnHit)
                {
                    if (particleEffect != null)
                    {
                        Instantiate(particleEffect, other.transform);
                    }
                    Destroy(this.gameObject, 0.2f);
                }
                else
                {
                    if (particleEffect != null)
                    {
                        Instantiate(particleEffect, other.transform);
                    }
                    this.gameObject.SetActive(false);
                }
            }
            
        }
    }
}
