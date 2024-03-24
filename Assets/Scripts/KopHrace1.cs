using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KopHrace1 : MonoBehaviour
{
    public GameObject mic;
    private float distance;
    private Rigidbody2D micRigidbody;
    public float ShootPower = 18;

    public Direction currentDirection = Direction.Right; // Výchozí směr

    void Start()
    {
        // Inicializace Rigidbody2D míče
        if (mic != null) // Zkontrolujte, zda je nastavena reference na míč
        {
            micRigidbody = mic.GetComponent<Rigidbody2D>(); // Získejte Rigidbody2D komponentu míče
        }
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput > 0)
        {
            currentDirection = Direction.Right;
        }
        else if (moveInput < 0)
        {
            currentDirection = Direction.Left;
        }

        distance = Vector2.Distance(transform.position, mic.transform.position);

        if (distance < 2 && Input.GetKeyDown(KeyCode.S))
        {
            KickBall();
        }
    }

    void KickBall()
    {
        Vector2 kickDirection = Vector2.up; 

        if (currentDirection == Direction.Right)
        {
            kickDirection += Vector2.right; 
        }
        else if (currentDirection == Direction.Left)
        {
            kickDirection += Vector2.left;
        }

        kickDirection.Normalize();
        if (micRigidbody != null)
        {
            micRigidbody.AddForce(kickDirection * ShootPower, ForceMode2D.Impulse);
        }
    }

    public enum Direction
    {
        Left,
        Right
    }
}
