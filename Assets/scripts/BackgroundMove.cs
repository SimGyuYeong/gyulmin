using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    private MeshRenderer render;

    [Header("���ӵ�")]
    [SerializeField]
    private float speed = 0.2f;

    private float offset;
    public UIManager uiManager;

    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<MeshRenderer>();
        uiManager = FindObjectOfType<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (uiManager.stageChange == false)
        {
            offset += Time.deltaTime * speed;
            render.material.mainTextureOffset = new Vector2(offset, 0);
        }
    }
}