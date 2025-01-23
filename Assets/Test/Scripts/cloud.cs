using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    private Transform T;
    // Start is called before the first frame update
    void Start()
    {
        T = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -1, 0) * Time.deltaTime;
        if(transform.position.y < -4)
        {
            transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 5.5f, 0);
        }
    }
}
