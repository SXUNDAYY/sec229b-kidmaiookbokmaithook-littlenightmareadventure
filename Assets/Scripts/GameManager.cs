using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("UI")]
    public GameObject winCanvas;
    public TMP_Text scoreTextWin; // ⭐ Text ในหน้า Win

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (winCanvas != null)
            winCanvas.SetActive(false);
    }

    public void WinGame()
    {
        if (winCanvas != null)
            winCanvas.SetActive(true);

        // ⭐ อัปเดตคะแนนตอนชนะ
        if (scoreTextWin != null)
        {
            scoreTextWin.text = "Score: " + ScoreManager.instance.score;
        }

        Time.timeScale = 0f;
    }
}