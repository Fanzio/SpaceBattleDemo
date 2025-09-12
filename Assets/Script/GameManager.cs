using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverScreen;
    public GameObject victoryScreen;

    private void Awake()
    {
        // Singleton: mantiene un’unica istanza
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void GameOver()
    {
        // Ferma il gioco e attiva gameOverScreen
        gameOverScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Ricarica scena
    }

    public void Victory()
    {
        victoryScreen.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GoToScene0()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);  // Carica la scena con indice 0
    }

    public void GoToScene1()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);  // Carica la scena con indice 1
    }
}