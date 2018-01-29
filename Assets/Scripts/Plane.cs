
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    public float speed;

    public Image countdown;

    public List<GameObject> estrellas;

    float totalTime;
    DateTime startTime;

    void Start()
    {
        startTime = DateTime.Now;
        var goal = GameObject.FindGameObjectWithTag("Finish");
        var distance = goal.transform.position.x - transform.position.x;
        totalTime = distance / speed;
    }
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
        float percent = 1 - (((DateTime.Now - startTime).Seconds * 1000 + (DateTime.Now - startTime).Milliseconds) / (1000 * totalTime));
        countdown.fillAmount = percent;

        if (percent < .66f)
        {
            estrellas[0].SetActive(false);
        }
        if (percent < .33f)
        {
            estrellas[1].SetActive(false);
        }

        if (percent <= 0)
        {
            SceneManager.LoadScene("Loser");
        }

    }
}