using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonShoot : MonoBehaviour
{
    [SerializeField] private Transform cannonHead;
    [SerializeField]  private Transform cannonTip;
    [SerializeField]  private float shootingCoolDown = 3f;
    [SerializeField]  private float laserPower = 100f;

    private bool isPlayerInRange;
    private GameObject player;
    private float timeLeftToShoot = 0;
    private LineRenderer cannonLaser;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cannonLaser = GetComponent<LineRenderer>();
        cannonLaser.sharedMaterial.color = Color.green;
        cannonLaser.enabled = false;
        timeLeftToShoot = shootingCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            cannonHead.transform.LookAt(player.transform);

            cannonLaser.SetPosition(0, cannonTip.transform.position);
            cannonLaser.SetPosition(1, player.transform.position);

            timeLeftToShoot -= Time.deltaTime;
        }

        if(timeLeftToShoot <= shootingCoolDown * 0.5)
        {
            cannonLaser.sharedMaterial.color = Color.red;
        }

        if(timeLeftToShoot <= 0)
        {
            Vector3 directionToPush = player.transform.position - cannonTip.transform.position;
            player.GetComponent<Rigidbody>().AddForce(directionToPush * laserPower, ForceMode.Impulse);
            cannonLaser.sharedMaterial.color = Color.green;
            timeLeftToShoot = shootingCoolDown;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            cannonLaser.enabled = true;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            cannonLaser.enabled = false;
            timeLeftToShoot = shootingCoolDown;
            cannonLaser.sharedMaterial.color = Color.green;
        }
    }
}
