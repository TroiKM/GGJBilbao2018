using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessengerCanvas : MonoBehaviour
{

    public GameObject pickerPanel;
    public GameObject chosenOne;

    public void ShowPicker()
    {
        pickerPanel.SetActive(true);
    }

    public void HidePicker(Sprite chosenOne)
    {
        this.chosenOne.GetComponent<Image>().sprite = chosenOne;
        pickerPanel.SetActive(false);
    }
}
