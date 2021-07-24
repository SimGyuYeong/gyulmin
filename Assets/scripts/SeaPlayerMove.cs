using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeaPlayerMove : MonoBehaviour
{
    private SeaBackground seaBackground = null;
    private float speed = 2f;
    private UIManager uIManager = null;
    private void Start()
    {
        seaBackground = FindObjectOfType<SeaBackground>();
        uIManager = FindObjectOfType<UIManager>();
    }
    void Update()
    {
        if(seaBackground.isPlayerMove == true)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if(transform.position.x > GameManager.Instance.landMaxPosition.x)
            {
                uIManager.stageChange = false;
                SceneManager.LoadScene("Main");
            }
        }
    }
}
