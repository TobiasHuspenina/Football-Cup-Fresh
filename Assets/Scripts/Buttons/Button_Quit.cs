using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button_Quit : MonoBehaviour
{
    // Metoda pro ukončení hry
    public void QuitGame()
    {
        // Vypíše zprávu do konzole (pouze pro účely ladění)
        Debug.Log("Ukončení hry");

        // Ukončí hru, pokud není spuštěna v Unity Editoru
        // V Unity Editoru jen vypíše zprávu do konzole
        #if UNITY_EDITOR
            // UnityEditor.EditorApplication.isPlaying = false; // Pro starší verze Unity
            UnityEditor.EditorApplication.ExitPlaymode(); // Od Unity 2021.2 a novější
        #else
            Application.Quit();
        #endif
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
