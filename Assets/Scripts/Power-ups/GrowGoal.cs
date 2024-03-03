using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowGoal : MonoBehaviour
{
    public GameObject brana1;
    public GameObject brana2;
    public float duration = 5f; // Doba trvání změny velikosti
    public float adjustmentFactor = 0.5f; // Faktor úpravy pozice brány

    private void Start()
    {
        brana1 = GameObject.FindGameObjectWithTag("Brana1");
        brana2 = GameObject.FindGameObjectWithTag("Brana2");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player1")
        {
            StartCoroutine(ResizeGoalTemporarily(brana2, 3.5f, duration, "BorderBrana2", new Vector3(13.89f, 1.91f, 0)));
        }
        else if (col.gameObject.tag == "Player2")
        {
            StartCoroutine(ResizeGoalTemporarily(brana1, 3.5f, duration, "BorderBrana1", new Vector3(-1.98f, 2.1f, 0)));
        }
    }

    IEnumerator ResizeGoalTemporarily(GameObject goal, float newSizeY, float duration, string borderTag, Vector3 newBorderPosition)
    {
        Vector3 originalSize = goal.transform.localScale;
        GameObject borderObject = GameObject.FindGameObjectWithTag(borderTag);
        Vector3 originalBorderPosition = borderObject.transform.position;

        // Vypočítáme rozdíl ve velikosti a upravíme pozici brány
        float sizeDifference = newSizeY - originalSize.y;
        Vector3 newPosition = goal.transform.position + new Vector3(0, (sizeDifference / 2) * adjustmentFactor, 0); 

        goal.transform.localScale = new Vector3(originalSize.x, newSizeY, originalSize.z);
        goal.transform.position = newPosition;

        // Nastavíme novou pozici border objektu
        borderObject.transform.position = newBorderPosition;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        yield return new WaitForSeconds(duration);

        // Po uplynutí doby vrátíme bránu i border na původní pozice a velikost
        goal.transform.localScale = originalSize;
        goal.transform.position -= new Vector3(0, (sizeDifference / 2) * adjustmentFactor, 0); 
        borderObject.transform.position = originalBorderPosition;

        Destroy(gameObject);
    }
}
