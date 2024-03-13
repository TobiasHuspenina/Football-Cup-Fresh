using UnityEngine.SceneManagement;
using UnityEngine;

public class Button_Controls : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayButton()
    {
        SceneManager.LoadScene(6);
    }
    
}
