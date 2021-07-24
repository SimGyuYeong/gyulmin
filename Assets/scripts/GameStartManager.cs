using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    private UIManager ui;
    private GameOverManager over;

    void Start()
    {
        ui = FindObjectOfType<UIManager>();
        over = FindObjectOfType<GameOverManager>();
    }

    public void GameStart()
    {
        SceneManager.LoadScene("Main");
        ui.scoreReset();
    }

    public void Quit()
    {
        over.quitClick();
    }
}

