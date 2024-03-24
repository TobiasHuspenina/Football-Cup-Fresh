using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 7f;
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

            bool isPlayer1OnOpponentsHalf = player1Transform.position.x > 0;

            if (isPlayer1OnOpponentsHalf)
            {
                MoveTowardsBall();
            }
            else
            {
                // Zastavení AI, pokud je vzdálenost mezi 4 a 6 jednotkami a hráč není na soupeřově půlce
                if (distanceToPlayer1 >= 4f && distanceToPlayer1 <= 6f)
                {
                    rb.velocity = Vector2.zero;
                }
                else if (distanceToPlayer1 < 4f)
                {
                    MoveAwayFromPlayer1();
                }
                else if (distanceToPlayer1 > 6f)
                {
                    MoveTowardsBall();
                }
            }

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
    Vector2 kickDirection = Vector2.up + Vector2.left;
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