using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tower : MonoBehaviour
{

    Animator myAnimator;

    public Transform top;

    bool readyToLaunch = false;

    bool hasTheMessenger = false;

    public GameObject messenger;

    int opportunities = 0;

    DateTime bendStartTime;

    public float margen = 3;

    public float force = 5;

    public GameObject arrowPrefab;
    public GameObject messengerCanvas;
    public GameObject joint;

    GameObject arrow;

    Vector3 direction;
    float strength;
    Vector3 originalPosition;

    void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();
        originalPosition = joint.transform.position;
    }

    void OnMouseDown()
    {
        if (!hasTheMessenger) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        arrow.GetComponent<Animator>().speed = 0;

        direction = new Vector3(1, Mathf.Tan(Mathf.Deg2Rad * arrow.transform.eulerAngles.z), 0);
        Debug.LogWarning(direction);

        myAnimator.SetBool("UserTapping", true);

        bendStartTime = DateTime.Now;

        var clipLength = myAnimator.GetCurrentAnimatorStateInfo(0).length;  
        InvokeRepeating("WastedOpportunity", clipLength, clipLength);


    }

    void OnMouseUp()
    {
        if (!hasTheMessenger) return;
        if (EventSystem.current.IsPointerOverGameObject()) return;

        messengerCanvas.SetActive(false);
        CancelInvoke("WastedOpportunity");

        Debug.Log((DateTime.Now - bendStartTime).Milliseconds / 500f);
        var modifier = (DateTime.Now - bendStartTime).Milliseconds/500f;
        strength = force*modifier;
        Debug.LogWarning(strength);
        myAnimator.SetBool("UserTapping", false);

        GetComponentInChildren<Collider>().enabled = false;
        //Ready to launch
        readyToLaunch = true;
        GetComponent<AudioSource>().Play();

    }

    void Update()
    {
        if (readyToLaunch && Vector3.Distance(originalPosition, joint.transform.position) < margen)
        {
            Launch();
            readyToLaunch = false;
        }
    }

    private void Launch()
    {
        hasTheMessenger = false;
        var m = Instantiate(messenger, top.position, messenger.transform.rotation);
        m.GetComponent<Rigidbody>().AddForce(direction * strength*2);
        m.GetComponent<Messenger>().prefab = messenger;

        Camera.main.gameObject.AddComponent<Follow>().follow = m;

    }

    public void MessengerArrived()
    {
        hasTheMessenger = true;
        messengerCanvas.SetActive(true);
        arrow = Instantiate(arrowPrefab, top.position, arrowPrefab.transform.rotation);
    }

    public void PickMessenger(GameObject messenger)
    {
        this.messenger = messenger;
    }

    private void WastedOpportunity()
    {
        opportunities++;
        if (opportunities == 3)
        {
            Debug.LogError("Game Over");
        }
    }
}
