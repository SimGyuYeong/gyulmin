using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Vector2 landMaxPosition { get; private set; }
    public Vector2 landMinPosition { get; private set; }
    private static GameManager instance = null;
    private int stage = 1;
    [SerializeField]
    private GameObject slimePrefab = null;
    [SerializeField]
    private GameObject smalltreePrefab = null;
    public PoolManager Pool { get; private set; }
    private PlayerMove playermove;

    private void Awake()
    {
        Pool = FindObjectOfType<PoolManager>();
    }

    public static GameManager Instance
    {
        get
        {
            if(instance == null)
            {
                instance = FindObjectOfType<GameManager>();
            }
            return instance;
        }
    }

    protected private void Start()
    {
        playermove = FindObjectOfType<PlayerMove>();
        landMaxPosition = new Vector2(12f, -1f);
        landMinPosition = new Vector2(-12f, -3.5f);
        StartCoroutine(SpawnSlime());
        StartCoroutine(SpawnSmallTree());
    }

    private IEnumerator SpawnSlime()
    {
        float delay;
        float SpawnPointY;
        while(true)
        {
            delay = Random.Range(2f, 4f);
            SpawnPointY = Random.Range(-1f, -3.5f);
            GameObject slime;
            if(Pool.transform.childCount > 0)
            {
                slime = Pool.transform.GetChild(0).gameObject;
                slime.transform.SetParent(null);
                slime.transform.position = new Vector2(11f, SpawnPointY);
                slime.SetActive(true);
            }
            else
            {
                slime = Instantiate(slimePrefab, new Vector2(11f, SpawnPointY), Quaternion.identity);
                slime.transform.SetParent(null);
            }
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator SpawnSmallTree()
    {   
        float delay;
        float SpawnPointY;
        while (true)
        {
            delay = Random.Range(4f, 6f);
            if (stage >= 2)
            { 
                SpawnPointY = Random.Range(-1f, -3.5f);
                GameObject tree;
                tree = Instantiate(smalltreePrefab, new Vector2(11f, SpawnPointY), Quaternion.identity);
                tree.transform.SetParent(null);
            }
            yield return new WaitForSeconds(delay);
        }
    }


}