using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public void restartClick()
    {
        SceneManager.LoadScene("Main");
    }

    public void quitClick()
    {
        Application.Quit();
    }
}
