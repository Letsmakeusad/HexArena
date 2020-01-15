using Assets.Scripts.TestScript;
using Assets.Scripts.TestScript.Variables;
using UnityEngine;


public class Portal : MonoBehaviour
{
    public bool isClosed;
    public bool isUsed;
    public ElementType ElementType;
    public Transform teleportPad;
    public GameEvent OnPortalActivated;

    public GameObject PortalExplodeEffect;
    public Vector3 Offset = new Vector3(0, 2, 0);

    // TELEPORTS THE PLAYER TO THE OPOSITE PORTAL //
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isClosed == false)
        {
            OnPortalActivated.Raise();
            FieldEventManager.ChangeField(ElementType);
           GameObject go =  Instantiate(PortalExplodeEffect, (this.transform));
            go.transform.localPosition += Offset;
           
            //TO DO: VISUAL LOCKING OF THE PORTALS!!!           
            other.attachedRigidbody.MovePosition(teleportPad.position);
            other.GetComponent<UnitHealthController>().Energize(6);

            isClosed = true;
            isUsed = true;
            //  PortalManager.LockPortals();
            //PortalManager.PortalTriggered(this.FieldType);
        }
    }

     

    


    public void LockPortal()
    {
        
        isClosed = true;

    }

    public void UnlockPortal()
    {
        if (!isUsed)
        {
            isClosed = false;
        }
       
    }
}
