using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public new Light light;
    private bool isOn = false;
    BluetoothLib bt;

    private void Start()
    {
        bt = FindObjectOfType<BluetoothLib>();
    }


    public void LightSwitching()
    {

        if (FindObjectOfType<ZoneDetection>().getColliderName() == "LightTrigger")
        {
            if (!isOn)
            {
                Debug.Log("the Light is turned on");
                light.enabled = true;
                isOn = true;
                bt.send("a");
            }
            else
            {
                Debug.Log("the Light is turned off");
                light.enabled = false;
                isOn = false;
                bt.send("b");
            }
        }
        else
        {
            Debug.Log("Try again after moving into the LightTrigger Zone.");
        }
    }
}
