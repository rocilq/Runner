using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{

    public GameObject gameOverPanel; // referencia al panel de Game Over
    public Button retryButton; // referencia al bot�n de retry

    private void Start()
    {
        // Desactivar el panel de Game Over al inicio
        gameOverPanel.SetActive(false);

        // Agregar un listener al bot�n de retry
        retryButton.onClick.AddListener(Retry);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            // Ejecutar acci�n de perder y volver a empezar
            Debug.Log("Has perdido");
            // Aqu� puedes poner cualquier acci�n que quieras ejecutar cuando el jugador choque con un obst�culo
            // Por ejemplo, puedes reiniciar la posici�n del jugador o cargar de nuevo la escena

            ShowGameOverPanel();
        }
    }

    public void ShowGameOverPanel()
    {
        // Activar el panel de Game Over
        gameOverPanel.SetActive(true);

        // Pausar el juego
        Time.timeScale = 0;
    }

    public void Retry()
    {
        // Recargar la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        // Reanudar el juego
        Time.timeScale = 1;
    }
}
