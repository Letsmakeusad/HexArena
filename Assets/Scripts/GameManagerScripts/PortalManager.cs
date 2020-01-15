using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.GameManagerScripts
{
    public class PortalManager: MonoBehaviour
    {
        public List<Portal> Portals;

        void Awake()
        {
            Portals = GetComponentsInChildren<Portal>().ToList();
        }


        
        public void UnlockPortals()
        {
            foreach (var portal in Portals)
            {
                portal.UnlockPortal();
            }
        }

        public void ResetPortals()
        {
            foreach (var portal in Portals)
            {
                portal.isUsed = false;
                portal.isClosed = false;
            }
        }


        public void LockPortals()
        {
            foreach (var portal in Portals)
            {
                portal.LockPortal();
            }
        }


    }
}
