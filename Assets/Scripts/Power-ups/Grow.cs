using UnityEngine;
using System.Collections;

public class Grow : MonoBehaviour
{
    public float GrowTime = 5f;
    public Vector3 growthFactor = new Vector3(1.5f, 1.5f, 1f);

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

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        yield return new WaitForSeconds(GrowTime);

        player.transform.localScale = originalScale;

        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        isGrowing = false;
        Destroy(gameObject);
    }
}
