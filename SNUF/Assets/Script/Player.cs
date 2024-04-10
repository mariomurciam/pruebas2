using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Camera cam;
    public Animator ac;
    public Rigidbody rb;
    public float speed = 8;
    public float movX;
    public float movZ;
    public float mouseX;
    public float mouseY;
    private bool atc;
    private float timer = 0.3f;
    private float time;

    void Awake() {
        cam.transform.parent = transform;
        ac = gameObject.GetComponent<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        time = timer;
    }
    void FixedUpdate() {
        rb.velocity = new Vector3(atc?0:speed * movX, rb.velocity.y, atc?0:speed * movZ);
        if(mouseX != 0){
            cam.transform.RotateAround(transform.position,transform.up, mouseX*90*Time.deltaTime*2f);
            //transform.Rotate(Vector3.up, mouseX*90*Time.deltaTime*2f);
        }
        if(mouseY != 0){
            cam.transform.RotateAround(transform.position,transform.right, mouseY*90*Time.deltaTime*2f);
        }
        cam.transform.LookAt(transform);
        Vector3 ea = cam.transform.rotation.eulerAngles;
        cam.transform.rotation = Quaternion.Euler(new Vector3(ea.x, ea.y,0));
    }
    // Update is called once per frame
    void Update()
    {
        movX = -Input.GetAxisRaw("Horizontal");
        movZ = -Input.GetAxisRaw("Vertical");
        mouseX = Input.GetAxisRaw("Mouse X");
        mouseY = -Input.GetAxisRaw("Mouse Y");
        if( Input.GetKeyDown( KeyCode.Mouse0 ) && atc == false){
            ac.SetTrigger("atc");
            atc = true;
        }

        if(atc == true){
            if(timer <= 0){
                atc = false;
                timer = time;
            }else{
                timer -= Time.deltaTime;
            }
        }

        if(movX == 0 && movZ == 0){
            ac.SetBool("mov", false);
        }else{
            ac.SetBool("mov", true);
        }
        int direction = -(int)movZ + (-(int)movX * 10);
        ac.SetInteger("direction", direction);
    }
}
