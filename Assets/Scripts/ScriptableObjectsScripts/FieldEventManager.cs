using Assets.Scripts.TestScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.TestScript
{
    public class FieldEventManager : MonoBehaviour
    {
 
        public delegate void ChangeFieldTo(ElementType field);
        public static event ChangeFieldTo OnFieldChangedTo;
              
        public static void ChangeField(ElementType field)
        {
            OnFieldChangedTo?.Invoke(field);

        }
    }
}
