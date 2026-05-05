using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Time.timeScale = 1f; // รีเซ็ตเวลาให้เดินปกติก่อนเริ่มเล่น
        SceneManager.LoadSceneAsync("Level 1");
    }

    public void Credit()
    {
        Time.timeScale = 1f; // รีเซ็ตเวลาเพื่อให้ Animation ในหน้า Credit ทำงาน
        SceneManager.LoadSceneAsync("Credit Menu");
    }

    public void Menu()
    {
        Time.timeScale = 1f; // รีเซ็ตเวลาเผื่อกลับไปหน้าเมนูแล้วมีอนิเมชั่น
        SceneManager.LoadSceneAsync("Main Menu");
    }
}