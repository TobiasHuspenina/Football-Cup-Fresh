using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoalCheck : MonoBehaviour
{

    private int ScoreNum;
    private Pozice[] defaultPositions;
    public TMP_Text countdownText;

    // Start is called before the first frame update
    void Start()
    {
        ScoreNum = 0;
        countdownText.text = "" + 0;
        defaultPositions = FindObjectsOfType<Pozice>();
    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Mic")
        {

            ScoreNum += 1;
            countdownText.text = "" + ScoreNum;
            for (int i = 0; i < defaultPositions.Length; i++)
            {
                defaultPositions[i].ResetToDefaultPosition();

            }
            col.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Pause();
        }
    }

    public float pauseTime = 2f;

    public void Pause()
    {
        Time.timeScale = 0f;
        StartCoroutine(ResumeAfterDelay());
    }

    IEnumerator ResumeAfterDelay()
    {
        yield return new WaitForSecondsRealtime(pauseTime);
        Time.timeScale = 1f;
    }
}
