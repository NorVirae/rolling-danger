using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private bool isInRange = false;
    private Rigidbody rb;
    private GameObject player;
    [SerializeField]private float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (isInRange)
        {
            Vector3 playerPositon = player.transform.position - transform.position ;
            playerPositon.y = 0;
            rb.AddForce(playerPositon, ForceMode.VelocityChange);
            Vector3 velocityChange = playerPositon * speed *Time.fixedDeltaTime;
            velocityChange.y = 0;
            rb.velocity = velocityChange;
            Debug.Log(Time.fixedDeltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
}
