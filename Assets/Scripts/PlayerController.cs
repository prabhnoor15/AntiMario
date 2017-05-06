using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpPower = 30f;
    public float maxSpeed = 5f;
    private bool facingRight;

    private bool IsOnGround = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(move * maxSpeed, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null)
        {
            IsOnGround = true;
        }
    }
}
