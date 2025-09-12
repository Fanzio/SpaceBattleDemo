using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectShot : MonoBehaviour
{
    public GameObject projectilePrefab;  
    public float minFireRate = 3f;
    public float maxFireRate = 15f;
    private float nextFireTime;

    void Start()
    {
        // Imposta un tempo casuale iniziale per lo sparo
        SetRandomFireTime();
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            Shoot();
            // Imposta di nuovo un tempo casuale
            SetRandomFireTime();
        }
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, transform.position, Quaternion.identity);
    }

    void SetRandomFireTime()
    {
        // Tempo casuale tra minFireRate e maxFireRate
        nextFireTime = Time.time + Random.Range(minFireRate, maxFireRate);
    }
}