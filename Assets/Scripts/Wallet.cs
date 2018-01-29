using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wallet : MonoBehaviour
{
    int coins = 0;
    public int maxCoins = 5;
    public Sprite coinEarned;

    private void Start()
    {
        for (int i = maxCoins; i < 5; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void AddCoin()
    {
        transform.GetChild(coins).GetComponent<Image>().sprite = coinEarned;
        coins = Mathf.Min(coins + 1, maxCoins);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddCoin();
        }
    }
}
