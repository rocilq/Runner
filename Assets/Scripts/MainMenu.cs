using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Load Scene
    public void Play()
    {
        SceneManager.LoadScene("Difficulty");
    }

    public void Options()
    {
        SceneManagerHelper.SetPreviousScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Options");
    }

    //Quit game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit the game");
    }
}
