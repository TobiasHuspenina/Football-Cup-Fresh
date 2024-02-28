using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour
{
    public float GrowTime = 5f;
    public Vector3 growthFactor = new Vector3(1.5f, 1.5f, 1f); // Faktor, o který se hráč zvětší

    private bool isGrowing = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            if (!isGrowing)
            {
                isGrowing = true;
                StartCoroutine(GrowForTime(collision.gameObject));
            }
        }
    }

    IEnumerator GrowForTime(GameObject player)
    {
        Vector3 originalScale = player.transform.localScale;
        Vector3 newScale = new Vector3(originalScale.x * growthFactor.x, originalScale.y * growthFactor.y, originalScale.z * growthFactor.z);

        player.transform.localScale = newScale;

        // Deaktivace renderování power-upu (zmizí vizuálně)
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        // Počkejte určený čas
        yield return new WaitForSeconds(GrowTime);

        // Vraťte hráče do původní velikosti
        player.transform.localScale = originalScale;

        // Aktivace renderování power-upu (objeví se znovu)
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        isGrowing = false;
        // Zničení objektu power-upu po aktivaci
        Destroy(gameObject);
    }
}
