using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public Collider2D col = null;
    private Animator ani;
    public bool isAttack = false;
    private string move;
    private float speed = 2f;

    [Header("체력")]
    [SerializeField]
    private float health = 5f;
    [Header("체력바")]
    [SerializeField]
    private Slider healthBar = null;
    [Header("이동속도")]
    [SerializeField]
    private float playerSpeed = 4f;

    public UIManager uiManager;
    private GameManager gm;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        ani = GetComponent<Animator>();
        healthBar.maxValue = health;
        healthBar.value = health;
        uiManager = FindObjectOfType<UIManager>();
        gm = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if(uiManager.stageChange == true)
        {
            col.enabled = false;
        }
        if (uiManager.stageChange == false)
        {
            if (move == "down")
            {
                if (transform.position.y < -3.5f) return;
                transform.Translate(Vector2.down * playerSpeed * Time.deltaTime);
            }
            else if (move == "up")
            {
                if (transform.position.y > -1f) return;
                transform.Translate(Vector2.up * playerSpeed * Time.deltaTime);
            }
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            if(transform.position.x >= gm.landMaxPosition.x)
            {
                SceneManager.LoadScene("Sea");
            }
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
            collision.transform.SetParent(gm.slimePool.transform, false);
            collision.gameObject.SetActive(false);
        }
    }

    private void playerDead()
    {
        PlayerPrefs.SetInt("SCORE", 0);
        PlayerPrefs.SetInt("STAGE", 1);
        PlayerPrefs.SetInt("TARGETSCORE", 10);
        SceneManager.LoadScene("Dead");
    }
}
