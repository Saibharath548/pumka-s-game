using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour
{
    private Transform T;
    public static float Speed;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one * Speed / 4;
        T = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0, -Speed, 0) * Time.deltaTime;
        if(transform.position.y < -7.5)
        {
            Speed = Random.Range(1f, 3f);
            transform.localScale = Vector3.one * Speed / 4;
            transform.position = new Vector3(Random.Range(-2.5f, 2.5f), 12f, 0);
        }
    }
}
