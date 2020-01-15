using Assets.Scripts.PowerUpScripts.RunTimeSpawnSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawnSystem : MonoBehaviour
{
    public ThingRuntimeSet EnabledPowerUps;
    public ThingRuntimeSet DisabledPowerUps;

    public float SpawnCooldown;
    public int MaxSpawnedPowerUps;
    private float cdLeft;
    public bool startSpawning;

    void Update()
    {
        startSpawning = EnabledPowerUps.Items.Count != MaxSpawnedPowerUps;
        if (startSpawning)
        {
            cdLeft -= Time.deltaTime;
            if(cdLeft <= 0)
            {
                SpawnPowerUp();
                cdLeft = SpawnCooldown;
                startSpawning = false;
            }

        }
        
    }

 
    public void DisableAll()
    {
        // Loop backwards since the list may change when disabling
        for (int i = EnabledPowerUps.Items.Count - 1; i >= 0; i--)
        {
            EnabledPowerUps.Items[i].gameObject.SetActive(false);
        }
    }

    public void DisableRandom()
    {
        int index = Random.Range(0, EnabledPowerUps.Items.Count);
        EnabledPowerUps.Items[index].gameObject.SetActive(false);
    }

    public void EnableAll()
    {
        // Loop backwards since the list may change when disabling
        for (int i = 5; i >= 0; i--)
        {
            DisabledPowerUps.Items[i].gameObject.SetActive(true);
        }
    }

    public void EnableRandom()
    {
        int index = Random.Range(0, DisabledPowerUps.Items.Count);
        DisabledPowerUps.Items[index].gameObject.SetActive(true);
        
    }

    public void SpawnPowerUp()
    {
        EnableRandom();
        
    }

    void OnEnable()
    {
        DisableAll();
    }
 
    void OnDisable()
    {
        DisabledPowerUps.Items.Clear();
    }


    
}
