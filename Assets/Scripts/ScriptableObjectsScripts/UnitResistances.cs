
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.TestScript.Variables
{
     

    [CreateAssetMenu(fileName = "Unit Resistances", menuName = "Resists")]
    public class UnitResistances : ScriptableObject
    {
        [System.Serializable]
        public struct Resistance
        {
            [SerializeField]
            public ElementType resistanceType;
            [SerializeField]
            public float percantageToReduce;
        }

        
        public List<Resistance> Resistances = new List<Resistance>();

        // CALCULATES THE DAMAGE AFTER % REDUCTION IS APPLIED
        public float CalculateDamageWithResistance(float damage, ElementType damageType)
        {
            for (int i = 0; i < Resistances.Count; i++)
            {
                if (Resistances[i].resistanceType == damageType)
                {
                    return ((damage * (1 - (Resistances[i].percantageToReduce) / 100)));

                }
            }
            return damage;
        }


        public void IncreaseResistance(ElementType resistanceType, float percentToIncrease)
        {
         //   Resistances.Where(x => x.resistanceType == resistanceType).Select(x => x.percantageToReduce += percentToIncrease);
           
        }

        public void ApplyProceduralResists(int resistsCount, float multiplier)
        {
            this.Resistances.Clear();
            var resistList = new List<int>() { 0, 1, 2, 3, 4, 5, };
            var counter = 0;
            var resistToAdd = new List<int>(resistsCount);
            while(counter < resistsCount)
            {
                var randomNum = Random.Range(0, resistList.Count);
                if (!resistToAdd.Contains(randomNum))
                {
                    resistToAdd.Add(resistList[randomNum]);
                    resistList.Remove(randomNum);
                    counter++;
                }
            }

            foreach (var id in resistToAdd)
            {
                Resistances.Add(new Resistance() { resistanceType = (ElementType)id, percantageToReduce = multiplier });
            }
 
        }
    }
}
