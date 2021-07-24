using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    private float speed = 0.2f;
    public Collider2D col = null;
    private Animator ani;
    public bool isAttack = false;
    private string move;

    [Header("체력")]
    [SerializeField]
    private float health = 5f;
    [Header("체력바")]
    [SerializeField]
    private Slider healthBar = null;
    [Header("이동속도")]
    [SerializeField]
    private float playerSpeed = 4f;

    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        healthBar.maxValue = health;
        healthBar.value = health;
    }

    void Update()
    {
        if (move == "down")
        {
            if(transform.position.y < -3.5f) return;
            transform.Translate(Vector2.down * playerSpeed * Time.deltaTime);
        } else if (move == "up")
        {
            if (transform.position.y > -1f) return;
            transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
        }
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

    public void UpMoveUp()
    {
        move = "stop";
    }

    public void UpMoveDown()
    {
        move = "up";
    }

    public void DownMoveUp()
    {
        move = "stop";
    }

    public void DownMoveDown()
    {
        move = "down";
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            health--;
            healthBar.value = health;
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
