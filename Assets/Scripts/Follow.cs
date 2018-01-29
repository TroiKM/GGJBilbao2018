using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject follow;
    Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = follow.transform.position - transform.position;
        Debug.LogWarning(offset);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(follow.transform.position.x - offset.x, transform.position.y, transform.position.z);
	}
}
