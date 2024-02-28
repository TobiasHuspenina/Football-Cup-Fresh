using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Menu: MonoBehaviour
{
    public void PlayButton()
    {
        SceneManager.LoadScene(0);
    }
}
