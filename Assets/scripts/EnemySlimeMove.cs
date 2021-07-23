using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemySlimeMove : MonoBehaviour
{
    protected bool isDead = false;
    protected bool isDamaged = false;
    [SerializeField]
    protected float speed = 2f;
    protected bool isMove = false;
    protected Animator animator;
    protected Collider2D col;
    protected SpriteRenderer spriteRenderer;
    protected PlayerMove playermove;

    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SlimeMove());
        playermove = FindObjectOfType<PlayerMove>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (isMove)
        {
            if (isDead == false)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        }
        CheckLimit();
    }

    protected void CheckLimit()
    {
        if (transform.position.x < GameManager.Instance.landMinPosition.x)
            StartCoroutine(Dead());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Stick")
        {
            if (playermove.isAttack)
            {
                isDead = true;
                StartCoroutine(Dead());
            }
        }
    }

    private IEnumerator SlimeMove()
    {
        while (true)
        {
            isMove = true;
            yield return new WaitForSeconds(1f);
            isMove = false;
            yield return new WaitForSeconds(0.25f);
        }
    }

    protected virtual IEnumerator Dead()
    {
        col.enabled = false;
        animator.Play("SlimeDie");
        yield return new WaitForSeconds(0.4f);
        transform.SetParent(GameManager.Instance.Pool.transform, false);
        gameObject.SetActive(false);
        isDead = false;
    }
}
