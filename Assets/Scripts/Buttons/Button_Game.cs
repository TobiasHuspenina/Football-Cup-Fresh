using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Game: MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(5);
    }
}
