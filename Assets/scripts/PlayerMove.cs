using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerMove : MonoBehaviour
{
    private Animator ani;
    public bool isAttack = false;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackClick()
    {
        StartCoroutine(Attack());
    }

    public IEnumerator Attack()
    {
        if (isAttack == false)
        {
            isAttack = true;
            ani.Play("playerAttack");
            yield return new WaitForSeconds(0.5f);
            ani.Play("player");
            isAttack = false;
        }
    }

    public void LeftMove()
    {
        if(transform.position.y + 1f > -1) return;
        transform.position = new Vector2(-9f, transform.position.y + 1f);
    }

    public void RightMove()
    {
        if (transform.position.y - 1f < -3f) return;
        transform.position = new Vector2(-9f, transform.position.y - 1f);
    }
}
