using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Spin the object at a specified speed
/// </summary>
public class SpinFree : MonoBehaviour {

    [HideInInspector]
    public bool spinParent;
    [HideInInspector]
    public float speed = 10f;
    public GameObject flag;


    [HideInInspector]
    public bool clockwise = true;
    [HideInInspector]
    public float direction = 1f;
    [HideInInspector]
    public float directionChangeSpeed = 2f;
    GameObject particle;
    float initial_pos = 0f;
    float end_pos = 0f;
    float dist = 0f;
    public Sprite[] flags;
    public GameObject[] panels;
    public static string mapToPlay;

    // Update is called once per frame
    void Update() {

        if (Input.GetMouseButtonDown(0))
        {
            initial_pos = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0))
        {
            end_pos = Input.mousePosition.x;
            speed = initial_pos > end_pos ? initial_pos - end_pos : end_pos - initial_pos;
            if (speed >= 42)
                speed = 42;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000.0f))
            {
                int num_flag = 0;
                if (hit.collider.gameObject.tag == "Flags")
                {
                    switch (hit.collider.gameObject.name)
                    {
                        case "Francia":
                            mapToPlay = "Map";
                            num_flag = 0;
                            break;
                        case "Italia":
                            mapToPlay = "Map";
                            num_flag = 1;
                            break;
                        case "Mexico":
                            mapToPlay = "Map";
                            num_flag = 2;
                            break;
                        case "Egipto":
                            mapToPlay = "Map";
                            num_flag = 3;
                            break;
                        case "India":
                            mapToPlay = "Map";
                            num_flag = 4;
                            break;
                        case "Brasil":
                            mapToPlay = "Map";
                            num_flag = 5;
                            break;
                        case "Japon":
                            num_flag = 6;
                            mapToPlay = "Japon";
                            break;
                        case "Rusia":
                            mapToPlay = "Map";
                            num_flag = 7;
                            break;
                        case "Australia":
                            mapToPlay = "Map";
                            num_flag = 8;
                            break;
                        case "USA":
                            mapToPlay = "Map";
                            num_flag = 9;
                            break;
                        case "Euskadi":
                            num_flag = 10;
                            mapToPlay = "EH";
                            break;
                        case "Venezuela":
                            num_flag = 11;
                            mapToPlay = "Venezuela";
                            break;
                        default:
                            break;
                    }
                        
                }
                flag.GetComponent<Image>().sprite = flags[num_flag];
                panels[0].SetActive(true);
                panels[1].SetActive(true);
            }
        }

        if (initial_pos != 0 && end_pos != 0)
        {
            if (direction < 1f)
            {
                direction -= Time.deltaTime / (directionChangeSpeed / 2);
            } 

            clockwise = initial_pos > end_pos ? true : false;

            direction = (clockwise) ? 1f : -1f;

            if (spinParent)
                transform.parent.transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
            else
                transform.Rotate(Vector3.up, (speed * direction) * Time.deltaTime);
        }
    }    
}