using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 7f;
    public float jumpForce = 10f;
    public Rigidbody2D ballRigidbody;
    public float kickStrength = 18f;
    private Rigidbody2D rb;
    private Transform ballTransform;
    private Transform player1Transform; // Transform pro Player1
    private bool isGrounded;
    private float kickCooldown = 1f;
    private float lastKickTime = -1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject ball = GameObject.FindGameObjectWithTag("Mic");
        if (ball != null)
        {
            ballTransform = ball.transform;
            ballRigidbody = ball.GetComponent<Rigidbody2D>();
        }

        // Najdeme objekt Player1 a uložíme jeho transform
        GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
        if (player1 != null)
        {
            player1Transform = player1.transform;
        }
    }

    void Update()
    {
        if (ballTransform != null && player1Transform != null)
        {
            float distanceToPlayer1 = Vector2.Distance(transform.position, player1Transform.position);

            // Zastavení AI, pokud je vzdálenost mezi 4 a 6 jednotkami
            if (distanceToPlayer1 >= 4f && distanceToPlayer1 <= 6f)
            {
                rb.velocity = Vector2.zero; // AI se zastaví
            }
            else if (distanceToPlayer1 < 4f)
            {
                // AI couvá, pokud je příliš blízko
                MoveAwayFromPlayer1();
            }
            else if (distanceToPlayer1 > 6f)
            {
                // AI se pohybuje směrem k míči, pokud je dále než 6 jednotek od Player1
                MoveTowardsBall();
            }

            // Zajištění, že kopnutí proběhne s určitou frekvencí
            if (CanKickBall(distanceToPlayer1))
            {
                KickBall();
            }
        }
    }

    void MoveAwayFromPlayer1()
    {
        float direction = Mathf.Sign(transform.position.x - player1Transform.position.x);
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    void MoveTowardsBall()
    {
        float directionToBall = Mathf.Sign(ballTransform.position.x - transform.position.x);
        rb.velocity = new Vector2(directionToBall * speed, rb.velocity.y);
    }

    bool CanKickBall(float distanceToPlayer1)
    {
        return Vector2.Distance(transform.position, ballTransform.position) <= 2f && Time.time - lastKickTime >= kickCooldown && distanceToPlayer1 >= 4f;
    }

    void KickBall()
    {
        Vector2 kickDirection = Vector2.up; // Základní směr je nahoru
        if (ballTransform.position.x > transform.position.x)
        {
            kickDirection += Vector2.right;
        }
        else
        {
            kickDirection += Vector2.left;
        }
        kickDirection.Normalize();
        ballRigidbody.AddForce(kickDirection * kickStrength, ForceMode2D.Impulse);
        lastKickTime = Time.time;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            isGrounded = false;
        }
    }
}
