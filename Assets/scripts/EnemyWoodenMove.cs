using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWoodenMove : EnemySlimeMove
{
    private bool moveDirect;
    private float yspeed = 4f;
    private void MoveDirect()
    {
        if (transform.position.y > GameManager.Instance.landMaxPosition.y)
        {
            moveDirect = false;
        }
        if (transform.position.y < GameManager.Instance.landMinPosition.y)
        {
            moveDirect = true;
        }
    }
    protected override void Start()
    {
        yspeed = Random.Range(0f, 8f);
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    protected override void Update()
    {
        if (isDead == false)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (moveDirect)
                transform.Translate(Vector2.up * yspeed * Time.deltaTime);
            else
                transform.Translate(Vector2.down * yspeed * Time.deltaTime);
        }
        CheckLimit();
        MoveDirect();
    }

    protected override IEnumerator Dead()
    {
        col.enabled = false;
        animator.Play("WoodenDie");
        yield return new WaitForSeconds(1.1f);
        Destroy(gameObject);
    }
}
