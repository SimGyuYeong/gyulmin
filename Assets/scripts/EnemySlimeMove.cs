using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemySlimeMove : MonoBehaviour
{
    private bool isDead = false;
    private bool isDamaged = false;
    [SerializeField]
    private float speed = 2f;
    private bool isMove = false;
    private Animator animator;
    private Collider2D col;
    private SpriteRenderer spriteRenderer;
    private int hp = 2;
    private void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(SlimeMove());
    }

    // Update is called once per frame
    private void Update()
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

    private void CheckLimit()
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

    private IEnumerator Dead()
    {
        col.enabled = false;
        animator.Play("SlimeDie");
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }
}
