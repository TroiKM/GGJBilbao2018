using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    public Tower firstTower;
    public GameObject defaultMessenger;

	// Use this for initialization
	void Start () {
        firstTower.MessengerArrived();
        firstTower.PickMessenger(defaultMessenger);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
