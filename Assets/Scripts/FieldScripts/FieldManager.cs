using Assets.Scripts.ScriptableObjectsScripts;
using Assets.Scripts.TestScript;
using Assets.Scripts.TestScript.Variables;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FieldManager : MonoBehaviour
{
    public ElementTypeVariable CurrentActiveFieldType;
    public GameObject CurrentActiveFieldObject;
    public GameEvent OnFieldChanged;
    public List<Field> Fields;
    public float FieldsActiveTime;
  

    void Start()
    {
        Fields = new List<Field>(GetComponentsInChildren<Field>());
        for (int i = 0; i < this.Fields.Count; i++)
        {
            Fields[i].gameObject.SetActive(false);
        }
        StartField();
    }
    

    void OnEnable()
    {
        FieldEventManager.OnFieldChangedTo += ChangeField;
    }

    void OnDisable()
    {
        FieldEventManager.OnFieldChangedTo -= ChangeField;
    }

    public  void ChangeField(ElementType fieldType)
    {
            if(fieldType != ElementType.Neutral)
        {
            StartCoroutine(StartFieldSwitchToNeutral());
        }
           
            this.CurrentActiveFieldObject.SetActive(false);
            this.CurrentActiveFieldType.Value = fieldType;
            this.CurrentActiveFieldObject = Fields.Where(x => x.fieldType == fieldType).Select(x => x.gameObject).FirstOrDefault();
            this.CurrentActiveFieldObject.SetActive(true);
            this.OnFieldChanged.Raise();
            
     
    }

    void StartField()
    {
         
        int startingFieldIndex = Random.Range(0, 5);
        Fields[startingFieldIndex].gameObject.SetActive(true);
        this.CurrentActiveFieldObject = Fields[startingFieldIndex].gameObject;
        this.CurrentActiveFieldType.Value = CurrentActiveFieldObject.GetComponent<Field>().fieldType;
        this.OnFieldChanged.Raise();
    }
 
    IEnumerator StartFieldSwitchToNeutral()
    {
 
        var time = FieldsActiveTime;
        while (time >= 0)
        {

            time -= Time.deltaTime;
            yield return null;

        }
        ChangeField(ElementType.Neutral); 

 
    }
}
