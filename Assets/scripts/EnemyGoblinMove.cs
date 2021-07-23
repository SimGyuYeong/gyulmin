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
}
