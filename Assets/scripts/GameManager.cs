using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSinglestion<GameManager>
{
    public Vector2 landMaxPosition { get; private set; }
    public Vector2 landMinPosition { get; private set; }
    private int stage = 1;
    [SerializeField]
    private GameObject slimePrefab = null;
    [SerializeField]
    private GameObject smalltreePrefab = null;
    [SerializeField]
    private GameObject goblinPrefab = null;
    [SerializeField]
    private GameObject darktreePrefab = null;
    [SerializeField]
    private GameObject bigDarkTreePrefab = null;
    public SlimePool slimePool { get; private set; }
    public SmallTreePool smallPool { get; private set; }
    public DarkTreePool darkPool { get; private set; }
    public BigDarkTreePool bigDarkPool { get; private set; }
    public GoblinPool goblinPool { get; private set; }

    private void Awake()
    {
        slimePool = FindObjectOfType<SlimePool>();
        smallPool = FindObjectOfType<SmallTreePool>();
        darkPool = FindObjectOfType<DarkTreePool>();
        bigDarkPool = FindObjectOfType<BigDarkTreePool>();
        goblinPool = FindObjectOfType<GoblinPool>();
    }

    protected private void Start()
    {
        landMaxPosition = new Vector2(12f, -1.5f);
        landMinPosition = new Vector2(-12f, -3.5f);
        StartCoroutine(SpawnSlime());
        StartCoroutine(SpawnSmallTree());
        StartCoroutine(SpawnGoblin());
        StartCoroutine(SpawnBigDarktree());
        StartCoroutine(SpawnDarktree());
    }

    private void Update()
    {
        
    }

    private IEnumerator SpawnSlime()
    {
        float delay;
        float SpawnPointY;
        while (true)
        {
            if (stageChange == false)
            {
                delay = Random.Range(3f, 5f);
                SpawnPointY = Random.Range(-1.5f, -3.5f);
                GameObject slime;
                if (slimePool.transform.childCount > 0)
                {
                    slime = slimePool.transform.GetChild(0).gameObject;
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
                if (smallPool.transform.childCount > 0)
                {
                    tree = smallPool.transform.GetChild(0).gameObject;
                    tree.transform.SetParent(null);
                    tree.transform.position = new Vector2(11f, SpawnPointY);
                    tree.SetActive(true);
                }
                else
                {
                    tree = Instantiate(smalltreePrefab, new Vector2(11f, SpawnPointY), Quaternion.identity);
                    tree.transform.SetParent(null);
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator SpawnGoblin()
    {
        float delay;
        float SpawnPointY;
        while (true)
        {
            delay = Random.Range(4f, 6f);
            if (stage >= 3)
            {
                SpawnPointY = Random.Range(-1f, -3.5f);
                GameObject goblin;
                if (goblinPool.transform.childCount > 0)
                {
                    goblin = goblinPool.transform.GetChild(0).gameObject;
                    goblin.transform.SetParent(null);
                    goblin.transform.position = new Vector2(11f, SpawnPointY);
                    goblin.SetActive(true);
                }
                else
                {
                    goblin = Instantiate(goblinPrefab, new Vector2(11f, SpawnPointY), Quaternion.identity);
                    goblin.transform.SetParent(null);
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator SpawnDarktree()
    {
        float delay;
        float SpawnPointY;
        while (true)
        {
            delay = Random.Range(10f, 16f);
            if (stage >= 4)
            {
                SpawnPointY = Random.Range(-1f, -3.5f);
                GameObject darktree;
                if (darkPool.transform.childCount > 0)
                {
                    darktree = darkPool.transform.GetChild(0).gameObject;
                    darktree.transform.SetParent(null);
                    darktree.transform.position = new Vector2(11f, SpawnPointY);
                    darktree.SetActive(true);
                }
                else
                {
                    darktree = Instantiate(darktreePrefab, new Vector2(11f, SpawnPointY), Quaternion.identity);
                    darktree.transform.SetParent(null);
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }

    private IEnumerator SpawnBigDarktree()
    {
        float delay;
        float SpawnPointY;
        while (true)
        {
            delay = Random.Range(10f, 16f);
            if (stage >= 5)
            {
                SpawnPointY = Random.Range(-1f, -3.5f);
                GameObject bigdarktree;
                if (bigDarkPool.transform.childCount > 0)
                {
                    bigdarktree = bigDarkPool.transform.GetChild(0).gameObject;
                    bigdarktree.transform.SetParent(null);
                    bigdarktree.transform.position = new Vector2(11f, SpawnPointY);
                    bigdarktree.SetActive(true);
                }
                else
                {
                    bigdarktree = Instantiate(bigDarkTreePrefab, new Vector2(11f, SpawnPointY), Quaternion.identity);
                    bigdarktree.transform.SetParent(null);
                }
            }
            yield return new WaitForSeconds(delay);
        }
    }
}
