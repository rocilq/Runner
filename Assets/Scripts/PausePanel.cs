using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public GameObject pausePanel; // referencia al panel de Game Over
    public Button returnButton; // referencia al botón de retry

    public static GameObject pauseMenu;

    private void Start()
    {

        // Agregar un listener al botón de retry
        returnButton.onClick.AddListener(Return);
    }

    public void Return()
    {
        // Activar el panel de Game Over
        pausePanel.SetActive(false);

        // Pausar el juego
        Time.timeScale = 1;
    }

    public void Options()
    {
        SceneManagerHelper.SetPreviousScene(SceneManager.GetActiveScene().name);

        SceneManager.LoadScene("Options");
    }

    public void Back()
    {
        // Recargar la escena actual
        SceneManager.LoadScene("MainMenu");
    }



}
