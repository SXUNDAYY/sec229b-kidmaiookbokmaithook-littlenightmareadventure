using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    [Header("UI Hearts")]
    public Image[] hearts;
    public Color fullColor = Color.white;
    public Color emptyColor = new Color(0.3f, 0.3f, 0.3f, 1f);

    [Header("Damage Settings")]
    public float invincibleTime = 1f;
    public float knockbackForce = 8f;

    [Header("Respawn")]
    public float respawnDelay = 1f;

    private bool isInvincible = false;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private Vector3 spawnPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        spawnPoint = transform.position; // ⭐ จำจุดเกิด

        currentHealth = maxHealth;
        UpdateHearts();
    }

    public void TakeDamage(int damage, Vector2 damageSourcePos)
    {
        if (isInvincible) return;

        currentHealth -= damage;
        if (currentHealth < 0) currentHealth = 0;

        UpdateHearts();

        // เด้งกลับ
        Vector2 direction = (transform.position - (Vector3)damageSourcePos).normalized;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(direction.x * knockbackForce, knockbackForce), ForceMode2D.Impulse);

        if (currentHealth == 0)
        {
            StartCoroutine(Respawn());
            return;
        }

        StartCoroutine(Invincible());
    }

    IEnumerator Respawn()
    {
        isInvincible = true;

        // ปิดตัวละครชั่วคราว
        sr.enabled = false;
        rb.linearVelocity = Vector2.zero;

        yield return new WaitForSeconds(respawnDelay);

        // วาร์ปกลับจุดเกิด
        transform.position = spawnPoint;

        // รีเลือด
        currentHealth = maxHealth;
        UpdateHearts();

        sr.enabled = true;

        // กันโดนซ้ำหลังเกิด
        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    IEnumerator Invincible()
    {
        isInvincible = true;

        for (int i = 0; i < 6; i++)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sr.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        yield return new WaitForSeconds(invincibleTime);
        isInvincible = false;
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].color = (i < currentHealth) ? fullColor : emptyColor;
        }
    }
}