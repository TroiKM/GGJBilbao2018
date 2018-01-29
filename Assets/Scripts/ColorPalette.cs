using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPalette : MonoBehaviour
{
    public Color coinTint;
    public Color windTint;
    public Color cloudTint;

    public Material coinMaterial;
    public Material windMaterial;
    public Material cloudMaterial;

    void Start()
    {
        foreach (var coin in GameObject.FindGameObjectsWithTag("Coin"))
        {
            TintCoin(coin);
        }

        foreach (var cloud in GameObject.FindGameObjectsWithTag("Cloud"))
        {
            TintCloud(cloud);
        }
    }

    public void TintCoin(GameObject coin)
    {
        if (coinMaterial != null)
        {
            coin.GetComponentInChildren<Renderer>().material = coinMaterial;
        }
        coin.GetComponentInChildren<Renderer>().material.color = coinTint;
    }

    public void TintWind(GameObject wind)
    {
        if (windMaterial != null)
        {
            wind.GetComponentInChildren<Renderer>().material = windMaterial;
        }
        wind.GetComponentInChildren<Renderer>().material.color = windTint;
    }

    public void TintCloud(GameObject cloud)
    {

        if (cloudMaterial != null)
        {
            cloud.GetComponentInChildren<Renderer>().material = cloudMaterial;
        }
        cloud.GetComponentInChildren<Renderer>().material.color = cloudTint;
    }
}
