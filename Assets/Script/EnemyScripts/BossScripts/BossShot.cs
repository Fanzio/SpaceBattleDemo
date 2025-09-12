using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShot : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -9;

    void Update()
    {
        // Controlla se non ci sono più "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        // Se il proiettile esce fuori dallo schermo in basso, viene distrutto
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }
}