using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void Credit()
    {
        SceneManager.LoadSceneAsync(4);
    }

    public void Menu()
    {
        SceneManager.LoadSceneAsync(1);
    }


}


