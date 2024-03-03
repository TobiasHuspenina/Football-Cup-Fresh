using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBall : MonoBehaviour
{
    public float duration = 5f; // Doba trvání efektu
    public Vector3 reducedSize = new Vector3(0.5f, 0.5f, 0.5f); // Nová velikost míče
    private Vector3 originalSize; // Původní velikost míče
    private GameObject ball; // Míč

    private void Start()
    {
        // Najdi míč podle tagu
        ball = GameObject.FindGameObjectWithTag("Mic");
        if (ball != null)
        {
            originalSize = ball.transform.localScale; // Ulož původní velikost míče
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Kontrola, zda se jedná o hráče
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            StartCoroutine(SizeDownkBall()); // Spustit efekt
        }
    }

    private IEnumerator SizeDownkBall()
    {
        ball.transform.localScale = reducedSize; // Zmenšení míče
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        yield return new WaitForSeconds(duration); // Počkej 5 sekund
        ball.transform.localScale = originalSize; // Vrátit na původní velikost
        Destroy(gameObject); // Zničení power-upu (nebo ho můžeš deaktivovat a znovu aktivovat později)
    }
}
