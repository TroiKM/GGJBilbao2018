using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class TextTyper : MonoBehaviour
{

    public float letterPause = 0.2f;
    public GameObject next;

    string message;
    Component father_mesh;
    Text textComp;

    // Use this for initialization
    void OnEnable()
    {
        textComp = GetComponent<Text>();
        message = textComp.text;
        textComp.text = "";
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            textComp.text += letter;
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        father_mesh = GetComponentInParent(typeof(Component));
        // Debug.Log(father_mesh.gameObject.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        father_mesh.gameObject.SetActive(false);
        if (next != null)
        {
            next.gameObject.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(4);
        }
        
    }
}