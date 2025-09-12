using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = -9;

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

        // Se esce dallo schermo, viene distrutto
        if (transform.position.y < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
