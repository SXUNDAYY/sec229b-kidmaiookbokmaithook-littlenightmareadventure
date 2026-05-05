using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Food food = collision.GetComponent<Food>();

        if (food != null)
        {
            ScoreManager.instance.AddScore(food.scoreValue);
            Destroy(collision.gameObject);
        }
    }
}