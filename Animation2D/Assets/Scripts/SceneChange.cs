using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    private SaveOnChange saveOnChange;
    [SerializeField] private int sceneChange;
    [SerializeField] private GameObject prefab;
    // Start is called before the first frame update
    void Awake()
    {
        saveOnChange = Singleton<SaveOnChange>.Instance;
        
            if (saveOnChange.lastScene == sceneChange)
            {
                Instantiate(prefab, transform.GetChild(0).transform.position, transform.rotation);
            }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            saveOnChange.lastScene = sceneChange;
            SceneManager.LoadScene(sceneChange);
        }
    }
}
