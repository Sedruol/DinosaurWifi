using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float minTime = 0.6f;
    [SerializeField] private float maxTime = 1.8f;
    private int randomIndex;
    private float randomTime;
    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            randomIndex = Random.Range(0, obstacles.Length);
            randomTime = Random.Range(minTime, maxTime);
            Instantiate(obstacles[randomIndex], transform.position, Quaternion.identity, transform);
            yield return new WaitForSeconds(randomTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnObstacle());
    }
}