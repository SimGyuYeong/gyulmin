using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private PlayerMove playerMove = null;
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
    }

    void Update()
    {
        if(playerMove.transform.position.x > GameManager.Instance.landMaxPosition.x)
        {
            SceneManager.LoadScene("Sea");
        }
    }
}
