using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void restartClick()
    {
        SceneManager.LoadScene("Start");
    }

    public void quitClick()
    {
        Application.Quit();
    }
}
