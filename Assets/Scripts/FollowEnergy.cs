using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnergy : MonoBehaviour
{
    Vector3 offset = new Vector3(-15, 0, -8);
    public Energy energy;

    public bool active = false;
    public float verticalLine;

    bool thrown = false;

    // Use this for initialization
    void Start()
    {
        energy.LandedCallback = Landed;
        energy.ThrownCallback = Thrown;
        verticalLine = energy.transform.position.z;
        transform.position = new Vector3(transform.position.x, transform.position.y, energy.transform.position.z + offset.z);

    }

    private void Landed()
    {
        Debug.Log("Lamadfasdf");
        active = false;
        verticalLine = energy.transform.position.z;
        thrown = false;
    }

    private void Thrown()
    {
        thrown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (thrown && energy.transform.position.z < verticalLine)
        {
            active = true;
        }
        if (active)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, energy.transform.position.z + offset.z);
        }
    }
}
