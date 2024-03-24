using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBall : MonoBehaviour
{
    public float duration = 5f;
    public Vector3 reducedSize = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 originalSize; 
    private GameObject ball;

    private void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Mic");
        if (ball != null)
        {
            originalSize = ball.transform.localScale;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1") || collision.gameObject.CompareTag("Player2"))
        {
            StartCoroutine(SizeDownkBall());
        }
    }

    private IEnumerator SizeDownkBall()
    {
        ball.transform.localScale = reducedSize;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }
        yield return new WaitForSeconds(duration);
        ball.transform.localScale = originalSize;
        Destroy(gameObject);
    }
}
