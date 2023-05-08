using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{

    public GameObject gameOverPanel; // referencia al panel de Game Over
    public Button retryButton; // referencia al botón de retry

    private void Start()
    {
        // Desactivar el panel de Game Over al inicio
        gameOverPanel.SetActive(false);

        // Agregar un listener al botón de retry
        retryButton.onClick.AddListener(Retry);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("obstacle"))
        {
            // Ejecutar acción de perder y volver a empezar
            Debug.Log("Has perdido");
            // Aquí puedes poner cualquier acción que quieras ejecutar cuando el jugador choque con un obstáculo
            // Por ejemplo, puedes reiniciar la posición del jugador o cargar de nuevo la escena

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
