using UnityEngine;
using UnityEngine.SceneManagement;

public class Difficulty : MonoBehaviour
{
    //Load Scene
    public void Easy()
    {
        SceneManager.LoadScene("nivelFacil");
    }
    public void Medium()
    {
        SceneManager.LoadScene("nivelMedio");
    }
    public void Hard()
    {
        SceneManager.LoadScene("nivelDificil");
    }
}
