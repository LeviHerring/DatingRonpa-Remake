using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewDetectorScript : MonoBehaviour
{

    
    [SerializeField] NPCScript NPC;
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
        Debug.Log("Trigger!");
        if(other.gameObject.CompareTag("NPC"))
        {
            NPC = other.GetComponent<NPCScript>();
            NPC.isHit = true; 
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        //NPC.isHit = false;
        NPC = null; 
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger!");
        if (other.gameObject.CompareTag("NPC"))
        {
            NPC = other.GetComponent<NPCScript>();
            NPC.isHit = true;
        }
    }
}
