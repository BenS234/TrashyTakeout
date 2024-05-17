using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public Vector3 moveDirection;
    public float speed;
    public GmScript Gm;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        if(Gm.doneDeal == false)
        {
            moveDirection = new Vector3(x, 0, z);
            transform.Translate(moveDirection * Time.fixedDeltaTime * speed);
        }
        
    }
    
}
