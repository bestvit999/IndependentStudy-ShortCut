using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDetection : MonoBehaviour {

    private string _Collider;

    public string getColliderName()
    {
        return _Collider;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other)
    {
        Debug.Log("You are entered in " + other.gameObject.name + " Zone.");
        _Collider = other.gameObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("You are Exited " + other.gameObject.name + " Zone.");
        _Collider = null;
    }

}
