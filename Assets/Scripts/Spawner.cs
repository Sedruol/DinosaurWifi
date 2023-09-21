using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    [SerializeField] private float minTime = 0.6f;
    [SerializeField] private float maxTime = 1.8f;
    private List<Transform> parentsObstacles = new List<Transform>();
    private int randomIndex;
    private float randomTime;
    private Transform RequestObstacle(int index)
    {
        Transform _transform = parentsObstacles[index];
        for (int x = 0; x < _transform.childCount; x++)
        {
            if (!_transform.GetChild(x).gameObject.activeSelf)
                return _transform.GetChild(x);
        }
        return null;
    }
    private IEnumerator SpawnObstacle()
    {
        while (true)
        {
            randomIndex = Random.Range(0, obstacles.Length);
            randomTime = Random.Range(minTime, maxTime);
            if (RequestObstacle(randomIndex) == null) randomIndex = Random.Range(0, obstacles.Length);
            else RequestObstacle(randomIndex).gameObject.SetActive(true);
            yield return new WaitForSeconds(randomTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        collision.transform.position = transform.position;
    }
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            parentsObstacles.Add(transform.GetChild(i));
        StartCoroutine(SpawnObstacle());
    }
}