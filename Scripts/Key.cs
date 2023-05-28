using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    [SerializeField] private Door doorToUnclock;
    [SerializeField] private float turningSpeed = 1.0f;
    private bool isDoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.Rotate(Vector3.up * Time.deltaTime * turningSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorToUnclock.UnlockDoor();
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (doorToUnclock != null)
        {
            Gizmos.color = Color.green;

            Gizmos.DrawRay(transform.position, doorToUnclock.transform.position - transform.position);
        }
    }
}
