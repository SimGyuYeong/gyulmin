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
        gm = FindObjectOfType<GameManager>();
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
        uiManager.AddScore();
        col.enabled = false;
        animator.Play("DarkTreeDie");
        yield return new WaitForSeconds(1.1f);
        transform.SetParent(gm.darkPool.transform, false);
        gameObject.SetActive(false);
        isMove = true;
        isDead = false;
        col.enabled = true;
    }
}
