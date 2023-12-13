using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioSource source;
    public AudioClip clip;
    public float speed = 5f;
    public float jumpForce = 5f;
    private bool jump;
    public float bounceForce = 10f;

    public bool computerMode;
    private Rigidbody2D rb;
    public BallController ball;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        //Debug.Log(jump);
    }

    void Move()
    {
        float horizontal;
        if (gameObject.CompareTag("Player"))
        {
            horizontal = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontal, 0);
            rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
        }
        else
        {
            if (computerMode)
            {
                if (!ball.grounding)
                {
                    Vector2 dir = (new Vector2(8.56f, rb.velocity.y) - rb.position).normalized;
                    rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
                }
                else
                {
                    Vector2 directionToBall = (ball.rb.position - rb.position).normalized;
                    rb.velocity = new Vector2(directionToBall.x * speed, rb.velocity.y);
                }
            }
            else
            {
                horizontal = Input.GetAxis("Horizontal2");
                Vector2 movement = new Vector2(horizontal, 0);
                rb.velocity = new Vector2(movement.x * speed, rb.velocity.y);
            }
        }
    }
    void Jumping()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jump = true;
        source.PlayOneShot(clip);
    }
    void Jump()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Jump") && !jump)
            {
                Jumping();
            }
        }
        else
        {
            if (computerMode)
            {
                if (Vector2.Distance(rb.position, ball.rb.position) < 8.0f && !jump)
                {
                    Jumping();
                }
            }
            else
            {
                if (Input.GetButtonDown("Jump2") && !jump)
                {
                    Jumping();
                }
            }
        }

    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jump = false;
        }
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody2D ballRigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

            if (ballRigidbody != null)
            { 
                Vector2 bounceDirection = (collision.transform.position - transform.position).normalized;

                ballRigidbody.velocity = bounceDirection * bounceForce;
            }
        }
    }
}
