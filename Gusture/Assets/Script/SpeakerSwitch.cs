using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerSwitch : MonoBehaviour {
    private bool isOn = false;
    BluetoothLib bt;

	// Use this for initialization
	void Start () {
        bt = FindObjectOfType<BluetoothLib>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpeakerSwitching()
    {
        if (FindObjectOfType<ZoneDetection>().getColliderName() == "SpeakerTrigger")
        {
            if (!isOn){

                Debug.Log("Speaker is turned on.");
                isOn = true;
                bt.send("f");
            }
            else
            {

                Debug.Log("Speaker is turned off.");
                isOn = false;
                bt.send("g");
            }
        }
        else
        {
            Debug.Log("Try again after moving into the FanTrigger Zone.");
        }
    }
}
