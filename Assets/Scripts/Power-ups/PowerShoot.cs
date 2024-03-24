using UnityEngine;
using System.Collections;

public class PowerShoot : MonoBehaviour
{
    public float duration = 10f;
    private bool isPower = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1") || other.CompareTag("Player2"))
        {
            if(!isPower){
            isPower = true;
            StartCoroutine(ApplyPowerShoot(other));
            }
        }
    }

    IEnumerator ApplyPowerShoot(Collider2D player)
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        if (player.CompareTag("Player1"))
        {
            var playerScript = player.GetComponent<KopHrace1>();
            playerScript.ShootPower += 10; 
            yield return new WaitForSeconds(duration);
            playerScript.ShootPower = 18;
            isPower = false;
        }
        else if (player.CompareTag("Player2"))
        {
            var playerScript = player.GetComponent<KopHrace2>();
            playerScript.ShootPower += 10; 
            yield return new WaitForSeconds(duration);
            playerScript.ShootPower = 18;
            isPower = false;
        }

        Destroy(gameObject); // Zničení objektu PowerUp
    }
}
