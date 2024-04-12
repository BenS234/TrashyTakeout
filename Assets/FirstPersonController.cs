using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed = 5.0f;
    private bool canJump;
    public Rigidbody rb;
    public float jumpForce;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        canJump = true;
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
    }

    //Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");


        moveDirection = new Vector3(x, 0, z);
        transform.Translate(moveDirection * Time.deltaTime * speed);
        
            
    }

    void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
