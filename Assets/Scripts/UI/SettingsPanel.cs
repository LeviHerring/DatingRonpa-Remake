using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class SettingsPanel : MonoBehaviour
{
    public PlayerCam playerCam;
    public TextMeshProUGUI sliderAmountText;
    public Slider sensitivitySlider;
    public float sliderAmount; 

    // Start is called before the first frame update
    void Start()
    {
      
        
    }

    // Update is called once per frame
    void Update()
    {
        sliderAmount = sensitivitySlider.value * 1000; 
        sliderAmountText.SetText(sliderAmount.ToString());
        playerCam.sensX = sliderAmount;
        playerCam.sensY = sliderAmount; 

    }
}
