using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigDarkTreeMove : EnemySlimeMove
{
    [SerializeField]
    private float bigDarkTreeHealth = 2f;

    private bool isDamaged = false;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stick")
        {
            if (playermove.isAttack)
            {
                if(isDamaged == false)
                {
                    isDamaged = true;
                    bigDarkTreeHealth--;
                    if (bigDarkTreeHealth == 0)
                    {
                        isDead = true;
                        isDamaged = false;
                        StartCoroutine(Dead());
                        return;
                    }
                    StartCoroutine(Damaged());
                }
            }
        }
    }

    private IEnumerator Damaged()
    {
        col.enabled = false;
        int i = 0;
        while(i < 5)
        {
            i++;
            transform.Translate(Vector2.right * 5f * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        col.enabled = true;
        isDamaged = false;
    }

    protected override IEnumerator Dead()
    {
        col.enabled = false;
        animator.Play("BigDarkTreeDie");
        yield return new WaitForSeconds(1.1f);
        transform.SetParent(GameManager.Instance.darkPool.transform, false);
        gameObject.SetActive(false);
        isMove = true;
        isDead = false;
        isDamaged = false;
        col.enabled = true;
    }
}
