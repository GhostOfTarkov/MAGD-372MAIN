using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject weapon;
    public GameObject bulletPrefab;
    public GameObject firePoint;
    public float fireRate = 0.25f;
    float cdTimer = 0;

 //   [SerializeField] private GameObject weapon;
 //   [SerializeField] private GameObject bullet;
 //   [SerializeField] private Transform bulletSpawnPoint;
 
   // private float nextFireTime;
   
    void Update()
    {
        cdTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cdTimer <= 0)
        {
            cdTimer = fireRate;
            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.transform.position, transform.rotation);
            bulletGO.layer = gameObject.layer;
        }
    }

}
