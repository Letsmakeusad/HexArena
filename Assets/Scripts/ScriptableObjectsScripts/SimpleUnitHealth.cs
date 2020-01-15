using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.TestScript.Variables
{
    public class SimpleUnitHealth : MonoBehaviour
    {
        public FloatVariable HP;

        public bool ResetHP;

        public FloatReference StartingHP;

        private void Start()
        {
            if (ResetHP)
                HP.SetValue(StartingHP);
        }

        private void OnTriggerEnter(Collider other)
        {
            DamageDealer damage = other.gameObject.GetComponent<DamageDealer>();
            if (damage != null)
                HP.ApplyChange(-damage.DamageAmount);
        }
    }
}
