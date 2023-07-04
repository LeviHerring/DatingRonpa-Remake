using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
public class OpeningUI : MonoBehaviour
{
    int timesPressedEscape = 0;
    public GameObject settingsPanel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            switch (timesPressedEscape)
            {
                case 0:
                    timesPressedEscape = 1; 
                    settingsPanel.SetActive(true);
                    Time.timeScale = 0;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    break;
                case 1:
                    timesPressedEscape = 0;
                    settingsPanel.SetActive(false);
                    Time.timeScale = 1;
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break; 
            }
        }
    }
}
