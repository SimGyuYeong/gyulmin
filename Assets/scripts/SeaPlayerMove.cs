using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SeaPlayerMove : MonoBehaviour
{
    private Animator animator = null;
    private SeaBackground seaBackground = null;
    private float speed = 2f;
    private UIManager uIManager = null;
    private int stage;
    private void Start()
    {
        animator = GetComponent<Animator>();
        stage = PlayerPrefs.GetInt("STAGE", 1);
        seaBackground = FindObjectOfType<SeaBackground>();
        uIManager = FindObjectOfType<UIManager>();
    }
    private void Update()
    {
        if(seaBackground.isPlayerMove == true)
        {
            if (transform.position.x > 6 && stage == 5)
            {
                StartCoroutine(Ending());
            }
            else
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            if(transform.position.x > 12f)
            {
                SceneManager.LoadScene("Main");
            }
        }
    }

    private IEnumerator Ending()
    {
        animator.Play("playerDead");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Clear");
    }
}
