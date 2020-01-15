using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopupEffect : MonoBehaviour
{
    public float destroyTime = 1f;
    public Vector3 Offset = new Vector3(0, 2, 0);

    void Start()
    {

        Destroy(gameObject, destroyTime);
        transform.localPosition += Offset;
    }

    
}
