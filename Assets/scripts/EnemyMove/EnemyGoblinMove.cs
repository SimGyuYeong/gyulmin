using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGoblinMove : EnemySlimeMove
{
    protected override void Update()
    {
            if (isDead == false)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
        CheckLimit();
    }

    protected override IEnumerator Dead()
    {
        uiManager.AddScore();
        col.enabled = false;
        animator.Play("GoblinDie");
        yield return new WaitForSeconds(1.1f);
        transform.SetParent(gm.goblinPool.transform, false);
        gameObject.SetActive(false);
        isMove = true;
        isDead = false;
        col.enabled = true;
    }
}
