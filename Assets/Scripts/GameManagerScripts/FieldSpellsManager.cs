using Assets.Scripts.ScriptableObjectsScripts;
using Assets.Scripts.TestScript.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameManagerScripts
{
    public class FieldSpellsManager: MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> FieldSpells;
        [SerializeField]
        
        void Start()
        {
            
          
        }

        public void ChangeFieldSpells(ElementTypeVariable CurrentActiveField)
        {
            DeactivateFieldSpells();
            switch (CurrentActiveField.Value)
            {

               
                case ElementType.Frost:
                     
                    FieldSpells[0].SetActive(true);
                     
                    break;
                case ElementType.Fire:

                    FieldSpells[1].SetActive(true);
                 
                    break;
                case ElementType.Nature:
                    FieldSpells[2].SetActive(true);
                   
                    break;
                case ElementType.Air:
                    FieldSpells[3].SetActive(true);
                 
                    break;
                case ElementType.Dark:
                    FieldSpells[4].SetActive(true);
                 
                    break;
                case ElementType.Light:
                    FieldSpells[5].SetActive(true);
                    
                    break;
                default:
                    break;
            }


        }
        private void DeactivateFieldSpells()
        {
            foreach (var item in FieldSpells)
            {
                item.gameObject.SetActive(false);
            }
        }
    }
}