using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour {
    public GameObject door;
    private float speed = 2;
    private bool isOn = false;
    public float degree=0;
    private BluetoothLib bt;

    // Use this for initialization
    void Start () {
        bt = FindObjectOfType<BluetoothLib>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isOn)
        {
            if (degree > (-90))
            {
                door.transform.Rotate(0, speed,0 );
                degree -= speed;
            }
        }
        else
        {
            if (degree < 0)
            {
                door.transform.Rotate(0, -speed,0 );
                degree += speed;
            }
        }
	}

    public void DoorSwitching()
    {
        if (FindObjectOfType<ZoneDetection>().getColliderName() == "DoorTrigger")
        {
            if (!isOn)
            {
                Debug.Log("the Door is opened.");
                isOn = true;
                bt.send("h");
                
            }
            else
            {
                Debug.Log("the Door is closed.");
                isOn = false;
                bt.send("i");
            }
        }
        else
        {
            Debug.Log("Try again after moving into the DoorTrigger Zone.");
        }
    }
}
