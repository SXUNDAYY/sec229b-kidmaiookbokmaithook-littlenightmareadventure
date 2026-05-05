using UnityEngine;

public class DamageSource : MonoBehaviour
{
    public int damage = 1;

    // ใช้กับ Collider ปกติ (ไม่ติ๊ก Is Trigger)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TryDamage(collision.gameObject);
    }

    // ใช้กับ Trigger (ติ๊ก Is Trigger)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryDamage(collision.gameObject);
    }

    void TryDamage(GameObject target)
    {
        PlayerHealth player = target.GetComponent<PlayerHealth>();

        if (player != null)
        {
            player.TakeDamage(damage, transform.position);
        }
    }
}