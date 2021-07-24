using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaBackground : MonoBehaviour
{
    private float speed = 0.2f;
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
