using Assets.Scripts.TestScript.Variables;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelUpdateScript : MonoBehaviour
{

    public TextMeshProUGUI text;
    public FloatVariable CurrentLevel;

    // Start is called before the first frame update
    void Start()
    {
        
        UpdateText();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateText()
    {
        this.text.text= $"Level: {CurrentLevel.Value}";
    }
}
