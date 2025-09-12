using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 0.3f;
    private float nextFireTime = 0f;

    void Update()
    {
        // Controlla input per sparare
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        nextFireTime = Time.time + fireRate;
    }
}
