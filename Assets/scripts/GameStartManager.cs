using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    private GameOverManager over;

    void Start()
    {
        over = FindObjectOfType<GameOverManager>();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        over.quitClick();
    }
}

