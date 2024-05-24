using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class Simple3DMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    [SerializeField]
    [Range(0.0f, 0.3f)]
    float RotationSmoothTime = 0.12f;
    public TMP_Text txtWin;
    float xMovement;
    float zMovement;
    float targetRotation;
    CharacterController characterController;
    float rotationVelocity;
    private int dots = 0;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }
    private void Start()
    {
        dots = GameObject.FindGameObjectsWithTag("Dot").Length;
        txtWin.text = "";
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Dot")
        {
            Destroy(other.gameObject);
            dots--;
        }
        if (other.gameObject.tag == "Enemy"){
            SceneManager.LoadScene(0);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Enemy"){
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(dots == 0){
            txtWin.text = "WIN!";
            Time.timeScale = 0;
        }

        xMovement = Input.GetAxisRaw("Horizontal");
        zMovement = Input.GetAxisRaw("Vertical");
        Vector2 move = new Vector2(xMovement, zMovement);

        Vector3 inputDirection = new Vector3(xMovement, 0.0f, zMovement).normalized;

        if (move != Vector2.zero)
        {
            targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                      Camera.main.transform.eulerAngles.y;

            float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref rotationVelocity,
                RotationSmoothTime);

            // rotate to face input direction relative to camera position
            transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            Vector3 targetDirection = Quaternion.Euler(0.0f, targetRotation, 0.0f) * Vector3.forward;

            // move the player
            //characterController.Move(targetDirection.normalized * (speed * Time.deltaTime));
            characterController.SimpleMove(targetDirection * speed);

        }

    }
}
