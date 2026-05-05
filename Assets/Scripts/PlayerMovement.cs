using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public int maxJumps = 2; // 2 = Double Jump

    private Rigidbody2D rb;
    private float moveInput;

    private int jumpCount = 0;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        // กระโดด (รวม Double Jump)
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            Jump();
            jumpCount++;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        // ล้างแรงตกก่อนกระโดด
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);

        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    // รีเซ็ต jump เฉพาะตอน "เหยียบพื้นจริง"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // เช็คว่าชนจากด้านล่าง (กันรีเซ็ตตอนชนกำแพง)
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.5f)
            {
                jumpCount = 0;
                break;
            }
        }
    }
}