namespace Assets.Scripts.ScriptableObjectsScripts
{
    using Assets.Scripts.GameManagerScripts;
    using Assets.Scripts.TestScript.Variables;
    using Kryz.CharacterStats;
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;
 
    public class ProceduralBossGenerator: MonoBehaviour
    {
        [Header("Procedural Resists Settings")]
        public UnitResistances BossResists;
        public int numberOfRandomResists;
        public float resistModifier;
        [Header("Procedural BaseStats Settings")]
        public CharacterStat BossMaxHealth;
        public CharacterStat BossMaxShield;
        [Header("Level Difficulty")]
        public LevelDifficulty LevelDifficulty;
        public FloatVariable CurrentLevel;

        [Header("Boss Models")]
        public List<Transform> BossModels;
        //TODO : ADD RANDOM SPELLS FOR USE;
        public GameObject ActiveBossModel;
          

        void Awake()
        {
            BossModels = this.gameObject.GetComponentsInChildren<Transform>().Where(go => go.gameObject != this.gameObject && go.gameObject.CompareTag("BossModel")).ToList();
            foreach (var boss in BossModels)
            {
                boss.gameObject.SetActive(false);
              
            }
            
        }

        public void GenerateBoss()
        {
            if(BossModels.Any(x=> x.gameObject.activeSelf == true))
            {
                foreach (var boss in BossModels)
                {
                    boss.gameObject.SetActive(false);

                }
            }

            BossResists.ApplyProceduralResists(numberOfRandomResists, resistModifier);
            var randomBossSpawnId = Random.Range(0, BossModels.Count);
             
            ActiveBossModel = BossModels[randomBossSpawnId].gameObject;
            ActiveBossModel.SetActive(true);
            
        }

        public void GenerateBaseStats()
        {

            this.BossMaxHealth.BaseValue = LevelDifficulty.LevelStats[(int)CurrentLevel.Value];
            this.BossMaxShield.BaseValue = LevelDifficulty.LevelStats[(int)CurrentLevel.Value];
        }

        public void DisableBoss()
        {
            this.ActiveBossModel.SetActive(false);
        }


       
    }
}
