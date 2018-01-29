
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{
    public List<GameObject> towers;

    const float width = 100;
    const float height = 100 / 1.6f;

    void Start()
    {
        var senderModel = towers[Random.Range(0, towers.Count)];
        var senderPosition = 10;
        var senderScale = Random.Range(1f, 3f);


        var receiverModel = towers[Random.Range(0, towers.Count)];
        var receiverPosition = Random.Range(70f, 90f);
        var receiverScale = Random.Range(1f, 3f);

        var sender = Instantiate(senderModel, new Vector3(senderPosition, -height / 2, 0), senderModel.transform.rotation);
        sender.transform.localScale = senderScale * Vector3.one;

        var senderTower = sender.GetComponentInChildren<Tower>();
        senderTower.MessengerArrived();

        var receiver = Instantiate(senderModel, new Vector3(receiverPosition, -height / 2, 0), receiverModel.transform.rotation);
        receiver.transform.localScale = receiverScale * Vector3.one;
    }
}