using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShotScript : MonoBehaviour
{
    public float moveSpeed = 5;
    public float deadZone = 8;
    public GameObject explosionPrefab;
    private PointManager pointManager;

    private int bossHitsToKill;
    private int enemyHitsToKill;

    private static int bossHits = 0;
    private static int enemyHits = 0;

    void Start()
    {
        // Recupera il gestore del punteggio dal GameManager presente in scena
        pointManager = GameObject.Find("GameManager").GetComponent<PointManager>();

        // Ottiene il nome della scena corrente (serve per regolare la difficoltà)
        string sceneName = SceneManager.GetActiveScene().name;

        // Configura quanti colpi servono per uccidere boss e nemici in base al livello
        if (sceneName == "First_Level")
        {
            enemyHitsToKill = 1;
            bossHitsToKill = 25;
        }
        else if (sceneName == "Second_Level")
        {
            enemyHitsToKill = 1;
            bossHitsToKill = 65;
        }
        else
        {
            enemyHitsToKill = 1;
            bossHitsToKill = 50;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

        // Se esce dallo schermo (troppo in alto), viene distrutto
        if (transform.position.y > deadZone)
        {
            Destroy(gameObject);
        }
    }

    // Gestisce le collisioni del proiettile
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Controlla se ci sono ancora nemici vivi (serve per abilitare l'attacco al boss solo a nemici eliminati)
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        // --- Caso 1: il proiettile colpisce un nemico semplice ---
        if (collision.gameObject.tag == "Enemy")
        {
            // Incrementa il contatore di colpi sul nemico
            enemyHits++;
            Debug.Log("Enemy hit: " + enemyHits + "/" + enemyHitsToKill);

            // Se il nemico ha subito abbastanza colpi → viene distrutto
            if (enemyHits >= enemyHitsToKill)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                pointManager.UpdateScore(50);
                enemyHits = 0;
            }
            // Distrugge il proiettile (ogni proiettile vale un colpo solo)
            Destroy(gameObject);
        }
        // --- Caso 2: il proiettile colpisce il boss (solo se tutti i nemici semplici sono morti) ---
        else if (collision.gameObject.tag == "Boss" && enemies.Length <= 0)
        {
            // Incrementa il contatore dei colpi sul boss
            bossHits++;
            Debug.Log("Boss hit: " + bossHits + "/" + bossHitsToKill);

            // Se il boss ha ricevuto abbastanza colpi → muore
            if (bossHits >= bossHitsToKill)
            {
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);

                // Grande ricompensa in punti
                pointManager.UpdateScore(1000);
            }
            else
            {
                // Ogni colpo al boss che non lo uccide dà comunque punti bonus
                Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                pointManager.UpdateScore(20);
            }
            // Anche in questo caso il proiettile viene distrutto
            Destroy(gameObject);
        }
    }
}