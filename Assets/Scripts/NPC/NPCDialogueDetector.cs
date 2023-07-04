using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 

public class NPCDialogueDetector : MonoBehaviour
{
    public GameObject textParent;
    public GameObject textChild;
    public NPCScript npcScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player has walked in");
            npcScript.isPlayerInRange = true; 
            textParent.SetActive(true);
            textChild.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        npcScript.isPlayerInRange = false; 
        textParent.SetActive(false);
        textChild.SetActive(false);
    }
}
