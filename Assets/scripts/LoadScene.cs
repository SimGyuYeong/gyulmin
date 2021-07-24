using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private PlayerMove playerMove = null;
    private GameManager gm;
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(playerMove.transform.position.x > gm.landMaxPosition.x)
        {
            SceneManager.LoadScene("Sea");
        }
    }
}
