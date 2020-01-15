using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleDestroyScript : MonoBehaviour
{
    [SerializeField] float DestroyAfter;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyAfter);
    }

    
}
