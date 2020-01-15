using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.TestScript.Variables
{
    [CreateAssetMenu]
    public class ElementTypeVariable : ScriptableObject
    {
#if UNITY_EDITOR
        [Multiline]
        public string DeveloperDescription = "";
#endif
        public ElementType Value;

        public void SetValue(ElementType value)
        {
            Value = value;
        }

        public void SetValue(ElementTypeVariable value)
        {
            Value = value.Value;
        }

        public void ApplyChange(ElementType amount)
        {
            Value = amount;
        }

        public void ApplyChange(ElementTypeVariable amount)
        {
            Value = amount.Value;
        }
    }
}
