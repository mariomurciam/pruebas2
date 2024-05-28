using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public TextMeshProUGUI text;
    private void Start() {
        text.text = "";
    }
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy"){
            SceneManager.LoadScene(0);
        }
        if (other.gameObject.tag == "End"){
            text.text = "WIN!";
        }
    }
}
