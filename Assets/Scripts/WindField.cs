using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindField : MonoBehaviour
{
    public Vector3 direction;

    List<Rigidbody> objectsInside;

    void Start()
    {
        objectsInside = new List<Rigidbody>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Onda") return;

        var rigid = collider.GetComponent<Rigidbody>();
        GetComponent<AudioSource>().Play();
        if (rigid != null)
        {
            objectsInside.Add(rigid);
        }
        Invoke("StopSound", 2);
    }

    public void StopSound()
    {
        GetComponent<AudioSource>().Pause();
    }

    void OnTriggerExit(Collider collider)
    {
        objectsInside.Remove(collider.GetComponent<Rigidbody>());
    }

    void Update()
    {
        foreach (var rigid in objectsInside)
        {
            rigid.AddForce(direction);
        }
    }
}
