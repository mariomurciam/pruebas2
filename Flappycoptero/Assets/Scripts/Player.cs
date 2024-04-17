using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    // Start is called before the first frame update
    void Awake()
    {
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
            QuitGame();
        }
        if (coll.gameObject.tag == "Coin")
        {
            Destroy(coll.gameObject);
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
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

}
