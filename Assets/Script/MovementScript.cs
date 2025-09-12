using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float hInput;
    public float vInput;

    void Update()
    {
        Move();
    }

    void Move()
    {
        // Legge gli input da tastiera (freccette / WASD)
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        // Calcola il movimento e lo applica
        Vector2 movement = new Vector2(hInput, vInput) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }
}
