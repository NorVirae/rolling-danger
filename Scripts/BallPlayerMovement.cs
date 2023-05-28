using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPlayerMovement : MonoBehaviour
{

    private Rigidbody rigBod;
    [SerializeField] private float speed = 30;
    [SerializeField] private float jumpForce = 4;
    private bool isJumping;
    private bool isGrounded;

    private float v, h;
    // Start is called before the first frame update
    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        Vector3 playerForceDirection = new Vector3(h, 0, v);
        rigBod.AddForce(playerForceDirection * speed, ForceMode.Acceleration);

        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, transform.localScale.x/2.0f + 0.01f )){
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

        if (isJumping && isGrounded)
        {
            rigBod.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    isGrounded = true; 
    //}

    //private void OnCollisionExit(Collision collision)
    //{
       // isGrounded = false;
    //}
}
