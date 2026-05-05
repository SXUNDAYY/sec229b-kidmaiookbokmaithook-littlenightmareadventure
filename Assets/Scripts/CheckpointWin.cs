using UnityEngine;

public class CheckpointWin : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // เช็คว่าเป็น Player
        if (collision.GetComponent<PlayerHealth>() != null)
        {
            GameManager.instance.WinGame();
        }
    }
}