using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Messenger : MonoBehaviour
{
    bool destroying = false;

    Wallet wallet;

    public Vector3 cloudBump;

    public GameObject prefab;
    public Sprite starOff, starOn;

    void Start()
    {
        wallet = GameObject.FindObjectOfType<Wallet>();
        Debug.Log("Start");
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("trigger");
        if (collider.tag == "Tower")
        {
            Debug.Log("trigger2");
            var tower = collider.GetComponent<Tower>();
            tower.MessengerArrived();
            tower.PickMessenger(prefab);
            destroying = true;
            Destroy(Camera.main.gameObject.GetComponent<Follow>());
            Destroy(gameObject);
            GameObject[] go = GameObject.FindGameObjectsWithTag("StarOff");
            go[0].tag = "StarOn";
            Color color = go[0].GetComponent<Image>().color;
            go[0].GetComponent<Image>().sprite = starOn;
            color = Color.white;
            color.a = 1.0f;
        }

        if (collider.tag == "Coin")
        {
            if (wallet != null)
            {
                wallet.AddCoin();
                Destroy(collider.gameObject.GetComponent<Renderer>());
                collider.GetComponent<AudioSource>().Play();
            }
        }

        if (collider.tag == "Finish")
        {
            Debug.LogWarning("Winnn");
            name = SceneManager.GetActiveScene().name;
            if (name == "EU") {
                SceneManager.LoadScene("EEUU");
            } else if (name == "EEUU")
            {
                SceneManager.LoadScene("Venezuela");
            } else {
                SceneManager.LoadScene("Win");
            }
        }

        if (collider.tag == "Cloud")
        {
            collider.GetComponent<Animator>().SetBool("Collision", true);
            GetComponent<Rigidbody>().AddForce(cloudBump);
            collider.GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Cloud")
        {
            collider.GetComponent<Animator>().SetBool("Collision", false);
        }
    }

    void Update()
    {
        if (transform.position.y < -40)
        {
            SceneManager.LoadScene("Loser");
        }
    }
}
