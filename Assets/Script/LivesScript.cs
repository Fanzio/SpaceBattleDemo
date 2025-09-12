using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesScript : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;

    public Sprite Ship1;
    public Sprite Ship2;
    public Sprite Ship3;

    public GameObject explosionPrefab;

    private SpriteRenderer characterSpriteRenderer;

    void Start()
    {
        characterSpriteRenderer = GetComponent<SpriteRenderer>();
        UpdateLivesUI();
        UpdateCharacterSprite();
    }

    void UpdateLivesUI()
    {
        // Aggiorna la UI mostrando solo il numero di vite rimaste
        for (int i = 0; i < livesUI.Length; i++)
        {
            livesUI[i].enabled = i < lives;
        }
    }

    void UpdateCharacterSprite()
    {
        // Cambia sprite in base al numero di vite rimaste
        if (lives == 2)
            characterSpriteRenderer.sprite = Ship1;
        else if (lives == 1)
            characterSpriteRenderer.sprite = Ship2;
        else if (lives == 0)
            characterSpriteRenderer.sprite = Ship3;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Se tocca un nemico, lo distrugge e perde una vita
        if (collision.collider.CompareTag("Enemy"))
        {
            Destroy(collision.collider.gameObject);
            LoseLife();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Se viene colpito da un proiettile nemico
        if (collision.CompareTag("Projectile"))
        {
            Destroy(collision.gameObject);
            LoseLife();
        }

        // Controllo vittoria: se non ci sono boss, si vince
        GameObject[] Boss = GameObject.FindGameObjectsWithTag("Boss");
        if (Boss.Length <= 0)
        {
            GameManager.instance.Victory();
        }
    }

    void LoseLife()
    {
        lives--;
        UpdateLivesUI();
        UpdateCharacterSprite();

        // Se le vite sono finite
        if (lives < 0)
        {
            ExplodeAndDestroy();
        }
    }

    void ExplodeAndDestroy()
    {
        // Effetto esplosione
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject); // Distrugge la nave
        GameManager.instance.GameOver();
    }
}