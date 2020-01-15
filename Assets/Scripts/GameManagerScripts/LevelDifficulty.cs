using Assets.Scripts.TestScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameManagerScripts
{
    [CreateAssetMenu(fileName ="LevelDifficultyMode", menuName ="Level Difficulties")]
    public class LevelDifficulty: ScriptableObject
    {
       
        public FloatReference BossScalingFactor;
        public FloatReference LevelCap;
        public List<int> LevelStats;

        void OnEnable()
        {
            LevelStats = new List<int>();
            GenerateScalingLevels();
        }

        
        void GenerateScalingLevels()
        {
            for (int i = 1; i < LevelCap; i++)
            {
                LevelStats.Add((int)(i * BossScalingFactor.Value));
            }
        }
    }
}
