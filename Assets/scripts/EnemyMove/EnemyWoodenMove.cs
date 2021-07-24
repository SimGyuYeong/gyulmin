using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWoodenMove : EnemySlimeMove
{
    private bool moveDirect;
    private float yspeed = 4f;
    private void MoveDirect()
    {
        if (transform.position.y > gm.landMaxPosition.y)
        {
            moveDirect = false;
        }
        if (transform.position.y < gm.landMinPosition.y)
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
        playermove = FindObjectOfType<PlayerMove>();
        gm = FindObjectOfType<GameManager>();
        uiManager = FindObjectOfType<UIManager>();
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
        uiManager.AddScore();
        col.enabled = false;
        animator.Play("WoodenDie");
        yield return new WaitForSeconds(1.1f);
        transform.SetParent(gm.smallPool.transform, false);
        gameObject.SetActive(false);
        col.enabled = true;
        isDead = false;
    }
}
