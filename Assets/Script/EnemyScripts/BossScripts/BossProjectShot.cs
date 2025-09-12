using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossProjectShot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 2f;
    private float nextFireTime;

    void Start()
    {
        nextFireTime = Time.time;
    }

    void Update()
    {
        // Se è passato abbastanza tempo dall’ultimo sparo
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Spara solo se non ci sono più "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}