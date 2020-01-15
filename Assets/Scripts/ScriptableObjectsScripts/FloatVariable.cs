using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.TestScript.Variables
{
    [CreateAssetMenu]
    public class FloatVariable  : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif

        public float Value;

     

        public void SetValue(float value)
        {
           
            Value = value;
        }

        public void SetValue(FloatVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(float amount)
        {
            Value += amount;
        }

        public void ApplyChange(FloatVariable amount)
        {
            Value += amount.Value;
        }

       
    }
}
