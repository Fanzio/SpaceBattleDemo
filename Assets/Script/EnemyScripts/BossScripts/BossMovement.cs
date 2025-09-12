using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement : MonoBehaviour
{
    public float moveSpeed = 2;
    public float targetYPosition = 35;

    void Update()
    {
        // Boss si muove solo se non ci sono più nemici normali
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length <= 0)
        {
            if (transform.position.y > targetYPosition)
            {
                // Scende fino al target
                transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            }
            else
            {
                // Poi si muove lateralmente
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Se colpisce un "Boundary", scende di una riga e inverte la direzione
        if (collision.gameObject.tag == "Boundary")
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 2, transform.position.z);
            moveSpeed *= -1;
        }
    }
}