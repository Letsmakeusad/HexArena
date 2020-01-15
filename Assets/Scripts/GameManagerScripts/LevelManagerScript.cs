using Assets.Scripts.GameManagerScripts;
using Assets.Scripts.TestScript.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    public FloatVariable Level;
     
    public GameEvent StartLevelEvent;
    public GameEvent LoadMainMenuEvent;
    public GameEvent StartNextLevelEvent;
 
    public bool ResetLevelOnStart;
 
    void  Awake()
    {
        if (ResetLevelOnStart)
            this.Level.Value = 1;
       //  StartLevelEvent.Raise();
       
    }


    
    public void ResetLevel()
    {
        StartLevelEvent.Raise();
        
    }

    public void StartLevel()
    {
        StartLevelEvent.Raise();

    }

    public void IncreaseLevel()
    {
        this.Level.Value++;
    }

    public void LoadMainMenu()
    {
        this.LoadMainMenuEvent.Raise();
    }

    public void StartNextLevel()
    {
        this.StartNextLevelEvent.Raise();
    }

    //IEnumerator ResetLevelCoroutine()
    //{
        
    //    StartLevelEvent.Raise();
        

    //}
}
