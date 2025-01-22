using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerT : MonoBehaviour
{
    [SerializeField] private GameObject[] Platforms;
    [SerializeField] private float PlatspawnTime;

    [SerializeField] private float timeuntilSpawn;
    [SerializeField] private float obstacleSpeed;

    private Vector3 spawnV;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        spawnV = new Vector3(Random.Range(-5, 5), 7, 0);
        spawnLoop();
    }

    private void spawnLoop()
    {
        timeuntilSpawn += Time.deltaTime;

        if (timeuntilSpawn > PlatspawnTime)
        {
            spawn();
            timeuntilSpawn = 0;
        }
    }
    private void spawn()
    {
        GameObject obstacleTospawn = Platforms[Random.Range(0, Platforms.Length)];

        GameObject spawnedObstacles = Instantiate(obstacleTospawn, spawnV, Quaternion.identity);

        Rigidbody2D obstacleRB = spawnedObstacles.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.down * obstacleSpeed;
    }
}
