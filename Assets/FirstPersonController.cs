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
    public GameObject projectile;
    public GameObject arm;
    public Transform projectileSpawn;
    public float projectileSpeed;
    public float delay;
    public bool canFire;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();
        canJump = true;
        canFire = true;
        delay = 0;
    }
    
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            canJump = false;
        }
        delay -= Time.deltaTime;
        if(delay < 0)
        {
            canFire = true;
            delay = 0.2f;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            if (canFire)
            {
                GameObject tempProjectile = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
                tempProjectile.GetComponent<Rigidbody>().AddForce(arm.transform.forward * projectileSpeed);
                canFire = false;
            }
        }

        arm.transform.LookAt(target.transform);
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
