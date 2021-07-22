using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject slimePrefab = null;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnSlime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnSlime()
    {
        float delay;
        float slimeSpawnPointY;
        while(true)
        {
            delay = Random.Range(2f, 4f);
            slimeSpawnPointY = Random.Range(-1f, -3.5f);
            GameObject slime;
            slime = Instantiate(slimePrefab, new Vector2(11f, slimeSpawnPointY), Quaternion.identity);
            slime.transform.SetParent(null);
            yield return new WaitForSeconds(delay);
        }
    }
}