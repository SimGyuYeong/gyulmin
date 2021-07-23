using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private Animator ani;
    public bool isAttack = false;
    [SerializeField]
    private float health = 5f;
    [SerializeField]
    private Slider durSlider = null;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        durSlider.maxValue = health;
        durSlider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackClick()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        if (isAttack == false)
        {
            isAttack = true;
            ani.Play("playerAttack");
            yield return new WaitForSeconds(0.5f);
            ani.Play("player");
            isAttack = false;
        }
    }

    public void UpMove()
    {
        if(transform.position.y + 1f > -1.5f) return;
        transform.position = new Vector2(-9f, transform.position.y + 1f);
    }

    public void DownMove()
    {
        if (transform.position.y - 1f < -3.5f) return;
        transform.position = new Vector2(-9f, transform.position.y - 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health--;
            durSlider.value = health;
            if (health == 0)
            {
                playerDead();
            }
            collision.transform.SetParent(GameManager.Instance.slimePool.transform, false);
            collision.gameObject.SetActive(false);
        }
    }

    private void playerDead()
    {
        SceneManager.LoadScene("Dead");
    }
}
