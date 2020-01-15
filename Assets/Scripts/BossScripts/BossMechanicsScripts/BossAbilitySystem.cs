using Assets.Scripts.BossScripts.BossMechanicsScripts;
using Assets.Scripts.ScriptableObjectsScripts;
using Assets.Scripts.TestScript.Variables;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BossAbilitySystem : MonoBehaviour
{
    
    public List<GameObject> BossAbilities;
    public GameObject CurrentActiveBossAbilities;
    public GameObject CurrentActiveAbility;
    public Transform BossAbilityPivot;
    public GameEvent ChangeBossPhase;
    public GameEvent StartCastingBossEvent;
    
    
    public float Cooldown = 10f;
    [SerializeField]
    private float cdTimeLeft;
    public bool startCasting;

    



    // Update is called once per frame
    void Update()
    {
        if (startCasting)
        {
            cdTimeLeft -= Time.deltaTime;
            
            if (cdTimeLeft < 0)
            {
                
                StartCastingBossEvent.Raise();
                UseRandomAbility();
                 
            }
        }
 
    }


    void UseRandomAbility()
    {
        
        var randomId = Random.Range(0, BossAbilities.Count);    

        CurrentActiveAbility = BossAbilities[randomId];
        // CurrentActiveAbility.GetComponent<BossAbility>().StartAbility(BossAbilityPivot);
        CurrentActiveAbility.SetActive(false);
        CurrentActiveAbility.SetActive(true);
        startCasting = false;
     //   CurrentActiveAbility = null;
    }

    public void StartCasting()
    {
        cdTimeLeft = Cooldown;
        startCasting = true;
        
    }

    public void ActivateBossAbilitiesComponent()
    {
        BossAbilities.Clear();
        CurrentActiveBossAbilities = GameObject.FindGameObjectWithTag("BossModel");
        var abilitiesHolder = CurrentActiveBossAbilities.transform.Find("BossAbilities");
        foreach (Transform ability in abilitiesHolder)
        { 
            BossAbilities.Add(ability.gameObject);
        }

      //  BossAbilityPivot = CurrentActiveBossAbilities.transform.Find("1");
        CurrentActiveBossAbilities.SetActive(true);
        
    }

    public void ResetCastingCooldown()
    {
        this.startCasting = false;
        this.cdTimeLeft = Cooldown;
        
       
    }
    
}
