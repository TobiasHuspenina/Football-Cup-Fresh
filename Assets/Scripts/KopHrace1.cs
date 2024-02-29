using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KopHrace1 : MonoBehaviour
{
    public GameObject mic; // Reference na míč
    private float distance;
    private Rigidbody2D micRigidbody; // Rigidbody míče pro aplikaci síly
    public int ShootPower = 18;

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
        Vector2 kickDirection = Vector2.up; // Základní směr je nahoru

        // Upravte směr podle toho, zda je hráč natočený doleva nebo doprava
        if (currentDirection == Direction.Right)
        {
            kickDirection += Vector2.right; // Přidáme vektor směrem doprava
        }
        else if (currentDirection == Direction.Left)
        {
            kickDirection += Vector2.left; // Přidáme vektor směrem doleva
        }

        kickDirection.Normalize(); // Normalizujeme vektor pro konzistentní velikost síly
        if (micRigidbody != null) // Zkontrolujte, zda má míč Rigidbody2D
        {
            micRigidbody.AddForce(kickDirection * ShootPower, ForceMode2D.Impulse); // Aplikujeme sílu
        }
    }

    public enum Direction
    {
        Left,
        Right
    }
}
