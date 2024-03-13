using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartingTime : MonoBehaviour
{
    public TMP_Text startingText;

    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        float countdown = 3;
        while (countdown > 0)
        {
            startingText.text = countdown.ToString();
            yield return new WaitForSecondsRealtime(1f);
            countdown--;
        }

        Time.timeScale = 1;
        startingText.gameObject.SetActive(false);
    }
}
