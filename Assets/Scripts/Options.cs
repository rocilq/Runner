using UnityEngine;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{


    public void Volver()
    {

        SceneManager.LoadScene(SceneManagerHelper.GetPreviousScene());

        if (PausePanel.pauseMenu != null)
        {
            PausePanel.pauseMenu.SetActive(true);
        }
    }
}
