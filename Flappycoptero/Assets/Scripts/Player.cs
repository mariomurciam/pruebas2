using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public TextMeshProUGUI txtCoin;
    private int coins;
    public TextMeshProUGUI txtStar;
    private int stars;
    public float speed = 8;
    public float movX;
    public float movY;
    private float chronometer = 0f;
    private int seg = 0;
    private int min = 0;
    public TextMeshProUGUI txtChrono;
    public ParticleSystem sistemaDeParticulas;
    // Start is called before the first frame update
    void Awake()
    {
        sistemaDeParticulas = GetComponent<ParticleSystem>();
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
        txtCoin.text = ": 0";
        coins = 0;
        txtStar.text = ": 0";
        stars = 0;
    }

    private void Points()
    {
        txtCoin.text = ": " + coins;
        txtStar.text = ": " + stars;
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            sistemaDeParticulas.Play();
            //SceneManager.LoadScene("SampleScene");
            //QuitGame();
        }
        if (coll.gameObject.tag == "Coin")
        {
            //Destroy(coll.gameObject);
            coins++;
            Points();
        }
        if (coll.gameObject.tag == "Star")
        {
            Destroy(coll.gameObject);
            stars++;
            Points();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(speed * movX, speed * movY, rb.velocity.z);
    }

    // Update is called once per frame
    void Update()
    {
        chronometer += Time.deltaTime;
        seg = (int)chronometer;
        if (seg >= 60)
        {
            min++;
            seg = 0;
            chronometer = 0;
        }
        txtChrono.text = (min < 10 ? "0" : "") + min + ":" + (seg < 10 ? "0" : "") + seg;


        movX = -Input.GetAxisRaw("Horizontal");
        movY = Input.GetAxisRaw("Vertical");

        if (transform.position.y >= 30f && movY > 0)
        {
            movY = 0;
        }
        if (transform.position.y <= -5f && movY < 0)
        {
            movY = 0;
        }

        if (transform.position.x >= 36f && movX > 0)
        {
            movX = 0;
        }
        if (transform.position.x <= -36f && movX < 0)
        {
            movX = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
