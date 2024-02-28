using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Cas : MonoBehaviour
{
    float currentTime;
    public float startingTime = 60f;
    public TMP_Text cas;
    public TMP_Text away;
    public TMP_Text home;

    void Start()
    {
        currentTime = startingTime;
    }
    void FixedUpdate()
    {

        currentTime += -1 * Time.deltaTime;
        cas.text = Mathf.Round (currentTime) +"";
        if (currentTime <= 10)
        {
            cas.color = Color.red;
        }

        if(currentTime <= 0){
            currentTime = 0;
             cas.text = "0";
             int num1 = int.Parse(away.text);//Player2
             int num2 = int.Parse(home.text);//Player1
        
        if (num1 > num2) //Player2 vyhrál
        {
            SceneManager.LoadScene(4);
        }
        else if (num2 > num1) //Player1 vyhrál
        {
            SceneManager.LoadScene(3);
        }
        else //Remíza
        {
            SceneManager.LoadScene(5);
         }
        }
    }

}