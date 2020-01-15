using Kryz.CharacterStats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.TestScript.Variables
{
    public class UnitHealthController : MonoBehaviour
    {
        [Header("Unit Health")]
        public CharacterStat UnitCurrentHealth;
        public CharacterStat UnitMaxHealth;
        [Header("Unit Shield")]
        public CharacterStat UnitCurrentShield;
        public CharacterStat UnitMaxShield;
        [Header("Unit Energy")]
        public CharacterStat UnitCurrentEnergy;
        public CharacterStat UnitMaxEnergy;
        [Header("Stats Settings")]
        public bool ResetHealthAtStart;
        public bool ResetShieldAtStart;
        public bool ResetEnergyAtStart;
        public bool HasShield;
        public bool hasManaRegen;
        public float manaPerSecond;
        [Header("Unit Resistances")]
        public UnitResistances UnitResistances;
        

        public UnityEvent DamageEvent;
        public GameEvent DeathEvent;
        public GameObject[] FloatingTextPrefabs;

        //TEST PURPOSE ONLY
        //private void Awake()
        //{
        //    this.UnitCurrentHealth = Instantiate(UnitCurrentHealth);
        //    this.UnitCurrentShield = Instantiate(UnitCurrentShield);

        //}
        float cd = 0;

        private void Start()
        {
            if (ResetHealthAtStart)
                ResetHealth();
            if (ResetShieldAtStart)
                ResetShield();
 
            if (ResetEnergyAtStart)
                ResetEnergy();
            if (!HasShield)
            {
                UnitCurrentShield.BaseValue= 0;
            }
        }

       


        public void TakeDamage(float damage, ElementType elementType)
        {

           var damageAfterResist = UnitResistances.CalculateDamageWithResistance(damage, elementType);
            if (this.UnitCurrentShield.Value - damageAfterResist >= 0)
            {
                this.UnitCurrentShield.BaseValue += (-damageAfterResist);
                
                    ShowFloatingText(damageAfterResist, elementType);
               
               
            }
            else 
            {

                this.UnitCurrentShield.BaseValue = 0;
                this.UnitCurrentHealth.BaseValue += (-(damageAfterResist - UnitCurrentShield.Value));
               
                    ShowFloatingText((damageAfterResist - UnitCurrentShield.Value), elementType);
               
                    
                if (UnitCurrentHealth.Value <= 0.0f)
                {
                    DeathEvent.Raise();
                    UnitCurrentHealth.BaseValue = 0;
                 
                }

            }
           
        }

        public void Heal(float amount)
        {
            
            if((this.UnitCurrentHealth.Value + amount) > UnitMaxHealth.Value)
            {
                this.UnitCurrentHealth.BaseValue = UnitMaxHealth.Value;
            }
            else
            {
                this.UnitCurrentHealth.BaseValue += amount;
            }
        }

        public void Shield(float amount)
        {

            if ((this.UnitCurrentShield.Value + amount) > UnitMaxShield.Value)
            {
                this.UnitCurrentShield.BaseValue = UnitMaxShield.Value;
            }
            else
            {
                this.UnitCurrentShield.BaseValue += amount;
            }
        }

        public void Energize(float amount)
        {
            
            if ((this.UnitCurrentEnergy.Value + amount) > UnitMaxEnergy.Value)
            {
                this.UnitCurrentEnergy.BaseValue = UnitMaxEnergy.Value;
                return;
            }
            this.UnitCurrentEnergy.BaseValue += amount;
            
        }

        public void ResetHealth()
        {
              UnitCurrentHealth.BaseValue = UnitMaxHealth.Value;
        }

        public void ResetShield()
        { 
            UnitCurrentShield.BaseValue = UnitMaxShield.Value;
        }

        public void ResetEnergy()
        {
            UnitCurrentEnergy.BaseValue = UnitMaxEnergy.Value;
        }

        public void ResetBossStats()
        {
            ResetHealth();
            ResetShield();
          //  ResetEnergy();
        }

        public void ResetPlayerStats()
        {
            ResetHealth();
          
            ResetShield();
            
            ResetEnergy();
        }


        void ShowFloatingText(float value, ElementType damageType)
        {

            if (FloatingTextPrefabs.Any())
            {
                var dmgPopUP = Instantiate(FloatingTextPrefabs[(int)damageType], transform.position, Quaternion.Euler(new Vector3(60, 0, 0)), transform);
                dmgPopUP.GetComponentInChildren<TextMeshPro>().text = value.ToString();
            }
         


        }


    }
}
