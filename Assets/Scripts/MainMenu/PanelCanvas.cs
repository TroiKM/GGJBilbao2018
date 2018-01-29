using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelCanvas : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
       // Debug.Log("Start");
    }

        // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    if (hit.collider.gameObject.tag == "Flag")
                    {
                        Debug.Log(hit.collider.gameObject.name);
                    }
                }
            }
        }
    }
}
