using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public int maxJumps = 2; // จำนวนครั้งที่กระโดดได้สูงสุด (2 คือ Double Jump)

    private Rigidbody2D rb;
    private float moveInput;
    private bool isGrounded;
    private int jumpCount; // ตัวนับจำนวนครั้งที่กระโดดไปแล้ว

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard != null)
        {
            // ระบบเดิน (New Input System)
            float moveLeft = keyboard.aKey.isPressed || keyboard.leftArrowKey.isPressed ? -1f : 0f;
            float moveRight = keyboard.dKey.isPressed || keyboard.rightArrowKey.isPressed ? 1f : 0f;
            moveInput = moveLeft + moveRight;

            // ระบบกระโดด Double Jump
            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                if (isGrounded || jumpCount < maxJumps)
                {
                    Jump();
                }
            }
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        // รีเซ็ตความเร็วในแนวตั้งก่อนกระโดดใหม่ เพื่อให้แรงกระโดดครั้งที่สองคงที่
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        
        jumpCount++; // เพิ่มจำนวนครั้งที่กระโดด
        isGrounded = false; // เมื่อกระโดดแล้ว สถานะบนพื้นจะเป็นเท็จทันที
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // เมื่อแตะพื้น (หรือวัตถุใดๆ) ให้รีเซ็ตจำนวนการกระโดด
        isGrounded = true;
        jumpCount = 0; 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        // ป้องกันกรณีเดินตกเหวโดยไม่ได้กระโดด ให้ถือว่าใช้สิทธิ์กระโดดครั้งแรกไปแล้ว (ถ้าอยากให้โดดในอากาศได้แค่ครั้งเดียว)
        if (isGrounded && jumpCount == 0)
        {
            jumpCount = 1;
        }
        isGrounded = false;
    }
}