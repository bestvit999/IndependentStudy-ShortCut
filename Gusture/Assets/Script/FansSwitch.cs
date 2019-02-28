using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FansSwitch : MonoBehaviour {

    public GameObject m_Object;
    public float m_RotationSpeed = 0f;
    public float maxSpeed = 10f;
    private bool isOn = false;
    BluetoothLib bt;

    private void Start()
    {
        bt = FindObjectOfType<BluetoothLib>();
    }

    private void Update()
    {
        if (isOn)
        {
            if (m_RotationSpeed < maxSpeed)
            {
                m_Object.transform.Rotate(0, 0, m_RotationSpeed);
                m_RotationSpeed += 0.01f;
            }
            else
            {
                m_Object.transform.Rotate(0, 0, maxSpeed);
            }
        }
        else
        {
            if (m_RotationSpeed > 0)
            {
                m_Object.transform.Rotate(0, 0, m_RotationSpeed);
                m_RotationSpeed -= 0.01f;
            }
            else
            {
                m_Object.transform.Rotate(0, 0, 0);
            }
        }
    }

    public void FansSwitching()
    {

        //判斷區域
        if (FindObjectOfType<ZoneDetection>().getColliderName() == "FanTrigger")
        {
            if (!isOn)
            {
                Debug.Log("the fan is turn on.");                
                isOn = true;
                bt.send("d");

            }
            else
            {
                Debug.Log("the fan is turn off.");
                isOn = false;
                bt.send("e");
            }
        }
        else
        {
            Debug.Log("Try again after moving into the FanTrigger Zone.");
        }
    }
}