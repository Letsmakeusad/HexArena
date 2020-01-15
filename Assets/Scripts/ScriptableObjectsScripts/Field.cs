using Assets.Scripts.TestScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjectsScripts
{
    [CreateAssetMenu(fileName ="Field", menuName ="Create Field")]
    public class Field : MonoBehaviour
    {
        public float FieldModifier;
        public ElementReference fieldType;
    }
}
