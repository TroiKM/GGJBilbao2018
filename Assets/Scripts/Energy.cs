
using UnityEngine;
using System;

public class Energy : MonoBehaviour
{
    Rigidbody myRigidbody;
    Vector3 stablePoint;
    public Action LandedCallback;
    public Action ThrownCallback;

    [SerializeField] float force;

    UserInteraction antenna;

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.isKinematic = true;

        stablePoint = transform.position;
    }

    public void Launch(Vector3 direction)
    {
        ThrownCallback();
        myRigidbody.isKinematic = false;
        myRigidbody.AddForce((direction).normalized * force);
        transform.SetParent(null);
    }

    void OnCollisionEnter(Collision collision)
    {
        LandedCallback();

        if (collision.gameObject.tag == "Finish")
        {
            Debug.Log("Winnnnnn!");
            myRigidbody.isKinematic = true;
        }

        if (collision.gameObject.tag == "antenna")
        {
            Debug.Log("Antenna hit");


            myRigidbody.isKinematic = true;

            antenna = collision.gameObject.GetComponent<UserInteraction>();
            transform.SetParent(antenna.topJoint.transform.parent);
            transform.localPosition = antenna.topJoint.localPosition;

            antenna.energy = this;

            antenna.GetComponent<Animator>().SetBool("CollisionEnter", true);

            stablePoint = transform.position;
        }
    }


    void OnBecameInvisible()
    {
        Debug.Log("Game over");
    }
}