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
    private int hp = 2;
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SlimeMove());
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
            Destroy(gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stick")
        {
            if (isDamaged) return;
            isDamaged = true;
            hp--;
            if (hp <= 0)
            {
                isDead = true;
                StartCoroutine(Dead());
            }
            isDamaged = false;
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
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }
}