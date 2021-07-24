using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBackground : MonoBehaviour
{
    public bool isPlayerMove = false;
    [SerializeField]
    private float speed = 2f;
    private Vector2 MaxPosition = new Vector2(-14f, 0);
    private void Update()
    {
        if (transform.position.x >= MaxPosition.x)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            isPlayerMove = true;
        }
    }
}
