using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private MeshRenderer render;

    [Header("배경속도")]
    [SerializeField]
    private float speed = 0.2f;

    private float offset;
    public UIManager uiManager;

    void Start()
    {
        render = GetComponent<MeshRenderer>();
        uiManager = FindObjectOfType<UIManager>();
    }

    void Update()
    {
        if (uiManager.stageChange == false)
        {
            offset += Time.deltaTime * speed;
            render.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}