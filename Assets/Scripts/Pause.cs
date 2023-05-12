using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public GameObject pausePanel;
    public void ButtonPause()
    {
        // Pausar
        Time.timeScale = 0;
        pausePanel.SetActive(true);

    }
}
