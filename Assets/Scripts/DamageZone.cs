using UnityEngine;

public class DamageZone : MonoBehaviour
{
    public int damage = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerHealth player = collision.gameObject.GetComponent<PlayerHealth>();

        if (player != null)
        {
            // ส่งตำแหน่งของดาเมจไปด้วย
            player.TakeDamage(damage, transform.position);
        }
    }
}