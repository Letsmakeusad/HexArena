// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;

namespace Assets.Scripts.PowerUpScripts.RunTimeSpawnSystem
{
    public class Thing : MonoBehaviour
    {
        public ThingRuntimeSet EnabledObjects;
        public ThingRuntimeSet DisabledObjects;
         

        private void OnEnable()
        {
            EnabledObjects.Add(this);
            DisabledObjects.Remove(this);
        }

        private void OnDisable()
        {
            EnabledObjects.Remove(this);
            DisabledObjects.Add(this);
        }
    }
}