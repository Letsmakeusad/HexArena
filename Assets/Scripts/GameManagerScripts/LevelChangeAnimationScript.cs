using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChangeAnimationScript : MonoBehaviour
{

    
    // Start is called before the first frame update
    void Awake()
    {
       
        DontDestroyOnLoad(this.gameObject);
    }

   
}
