using UnityEngine;

public class spawnerT : MonoBehaviour
{
    [SerializeField] private Sprite[] sp;
    public SpriteRenderer sR;

    [SerializeField] private GameObject[] Platforms;
    [SerializeField] private float PlatspawnTime;

    [SerializeField] private float timeuntilSpawn;
    [SerializeField] private float obstacleSpeed;

    private Vector3 spawnV;
    private Transform spawnT;
    // Start is called before the first frame update
    void Start()
    {
       // sR = GetComponent<SpriteRenderer>();

        spawnT = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        spawnV = new Vector3(Random.Range(-2, 2), 7, 0);
        spawnLoop();
        //sR.sprite = sp[Random.Range(0, sp.Length)];
        
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
    //GameObject InstantiateRandomScale(GameObject source, float minScale, float maxScale)
    //{
    //    GameObject clone = Instantiate(source) as GameObject;
    //    clone.transform.localScale = Vector3.one * Random.Range(minScale, maxScale);
    //    return clone;
    //}
    private void spawn()
    {

        GameObject obstacleTospawn = Platforms[Random.Range(0, Platforms.Length)];

        GameObject spawnedObstacles = Instantiate(obstacleTospawn, spawnV, Quaternion.identity);



        Rigidbody2D obstacleRB = spawnedObstacles.GetComponent<Rigidbody2D>();
        obstacleRB.velocity = Vector2.down * obstacleSpeed;
    }
}
