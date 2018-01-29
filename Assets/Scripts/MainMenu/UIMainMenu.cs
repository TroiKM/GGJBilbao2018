using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMainMenu : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void LoadGame()
    {
        //Level 1
        SceneManager.LoadScene(SpinFree.mapToPlay);
    }

    public void LoadHistory()
    {
        SceneManager.LoadScene("History");
    }

    public void LoadMap()
    {
        SceneManager.LoadScene("Map");
    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

    public void LoadCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
