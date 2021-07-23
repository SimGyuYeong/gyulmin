using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyDarkTreeMove : EnemySlimeMove
{
    protected override void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private IEnumerator DarkTreeMove()
    {
        while(true)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            CheckLimit();
            yield return new WaitForSeconds(2f);
        }
    }
    protected override IEnumerator Dead()
    {
        col.enabled = false;
        animator.Play("");
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }
}
