using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBigDarkTreeMove : EnemySlimeMove
{

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stick")
        {
            if (playermove.isAttack)
            {
                isDead = true;
                StartCoroutine(Dead());
            }
        }
    }

    protected override IEnumerator Dead()
    {
        uiManager.AddScore();
        col.enabled = false;
        animator.Play("BigDarkTreeDie");
        yield return new WaitForSeconds(1.1f);
        transform.SetParent(GameManager.Instance.darkPool.transform, false);
        gameObject.SetActive(false);
        isMove = true;
        isDead = false;
        col.enabled = true;
    }
}
