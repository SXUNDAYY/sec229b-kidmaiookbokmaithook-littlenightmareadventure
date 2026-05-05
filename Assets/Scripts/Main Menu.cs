using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level 1");
    }
    public void Credit()
    {
        SceneManager.LoadSceneAsync("Credit Menu");
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync("Main Menu");
    }


}


