using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Butons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }
}
