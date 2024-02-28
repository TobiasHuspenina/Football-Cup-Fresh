using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowGoal : MonoBehaviour
{
    public GameObject brana1;
    public GameObject brana2;
    public float duration = 5f; // Doba trvání změny velikosti

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player1")
        {
            StartCoroutine(ResizeGoalTemporarily(brana2, 5f, duration));
        }
        else if (col.gameObject.tag == "Player2")
        {
            StartCoroutine(ResizeGoalTemporarily(brana1, 5f, duration));
        }
    }

    IEnumerator ResizeGoalTemporarily(GameObject goal, float newSizeY, float duration)
    {
        Vector3 originalSize = goal.transform.localScale;
        goal.transform.localScale = new Vector3(originalSize.x, newSizeY, originalSize.z);

        yield return new WaitForSeconds(duration);

        goal.transform.localScale = originalSize;
    }
}