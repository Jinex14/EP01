using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpam : MonoBehaviour
{
    [SerializeField] private List<Vector2> pos;
    [SerializeField] private List<GameObject> prefabs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpamEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpamEnemy()
    {
        float randomNumber = Random.Range(1f, 2f);
        yield return new WaitForSeconds(randomNumber);
        int i = (int)Random.Range(0, prefabs.Count);
        Instantiate(prefabs[i], pos[i], prefabs[i].transform.rotation);
        StartCoroutine(SpamEnemy());
    }
}
