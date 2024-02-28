using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Freeze : MonoBehaviour
{
     public float freezeTime = 5f; // Doba, po kterou bude druhý hráč zmrazen

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            GameObject player2 = GameObject.FindGameObjectWithTag("Player2");
            if (player2 != null)
            {
                player2.GetComponent<Pohyb>().Freeze(freezeTime);
            }
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            GameObject player1 = GameObject.FindGameObjectWithTag("Player1");
            if (player1 != null)
            {
                player1.GetComponent<Pohyb>().Freeze(freezeTime);
            }
        }

        // Zničení nebo skrytí power-upu po aktivaci
        Destroy(gameObject);
    }
    }

