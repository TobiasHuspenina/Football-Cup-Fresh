using UnityEngine;
using System.Collections;

public class PowerShoot : MonoBehaviour
{
    public float duration = 10f; // Doba trvání PowerUp

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Zkontrolujeme, zda se dotkl hráč s potřebným tagem
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            StartCoroutine(ApplyPowerShoot(other));
        }
    }

    IEnumerator ApplyPowerShoot(Collider2D player)
    {
        // Deaktivace vizuální reprezentace PowerUp
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        // Rozpoznání a aplikace PowerUp
        if (player.CompareTag("Player1"))
        {
            var playerScript = player.GetComponent<KopHrace1>();
            playerScript.ShootPower += 10; // Přidání síly střely
            yield return new WaitForSeconds(duration);
            playerScript.ShootPower = 18; // Reset síly střely
        }
        else if (player.CompareTag("Player2"))
        {
            var playerScript = player.GetComponent<KopHrace2>();
            playerScript.ShootPower += 10; // Přidání síly střely
            yield return new WaitForSeconds(duration);
            playerScript.ShootPower = 18; // Reset síly střely
        }

        Destroy(gameObject); // Zničení objektu PowerUp
    }
}
