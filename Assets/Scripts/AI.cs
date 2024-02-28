using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float speed = 5f; // Rychlost pohybu AI
    public float jumpForce = 10f;
    public Rigidbody2D ballRigidbody; // Rigidbody míče
    public float kickStrength = 40f; // Síla kopnutí
    public float kickRange = 1f; // Dosah, ve kterém může AI kopnout do míče
    private Rigidbody2D rb;
    private Transform ballTransform; // Transform míče
    private bool isGrounded; // Kontrola, zda je AI na zemi
    private float kickCooldown = 1f; // Cooldown mezi kopnutími
    private float lastKickTime = -1f; // Čas posledního kopnutí

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject ball = GameObject.FindGameObjectWithTag("Mic");
        if (ball != null)
        {
            ballTransform = ball.transform;
            ballRigidbody = ball.GetComponent<Rigidbody2D>();
        }
    }

    void Update()
    {
        if (ballTransform != null)
        {
            float direction = ballTransform.position.x - transform.position.x;
            rb.velocity = new Vector2(Mathf.Sign(direction) * speed, rb.velocity.y);

            // Kontrola, zda je míč v dosahu kopnutí
            if (Vector2.Distance(transform.position, ballTransform.position) <= kickRange)
            {
                // Zajištění, že kopnutí proběhne s určitou frekvencí
                if (Time.time - lastKickTime >= kickCooldown)
                {
                    StartCoroutine(KickBall());
                    lastKickTime = Time.time;
                }
            }
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    // Detekujte kolize s podlahou, abyste aktualizovali stav isGrounded
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border")) // Ujistěte se, že tag "Border" je přiřazen všem povrchům, po kterých může AI skákat
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
    IEnumerator KickBall()
    {
        if (ballRigidbody != null)
        {
            Vector2 kickDirection = (ballRigidbody.position - (Vector2)transform.position).normalized;
            ballRigidbody.AddForce(kickDirection * kickStrength, ForceMode2D.Impulse);
        }

        yield return null; // Tento řádek můžete přizpůsobit, pokud potřebujete pauzu nebo další efekty při kopnutí
    }
}
