using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubble : MonoBehaviour
{
    private Transform T1;
    public Rigidbody2D Box;
    public Rigidbody2D rb2;
    public GameObject BG;
    bool inC;
    public static bool Move;
    public static bubble instance;
    public Animator Ani;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        Ani = GetComponent<Animator>();
        //rb2 = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        T1 = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(inC)
        {
            //transform.position += new Vector3(0, 1, 0)*Time.deltaTime;
            transform.localScale -= new Vector3(.1f, .1f, 0) * Time.deltaTime;
            movement.instance.transform.position = this.transform.position;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Move = true;
            inC = true;
            movement.instance.transform.position = T1.position;
            //transform.SetParent(movement.instance.transform);
            rb2.gravityScale = 0;
            Box.bodyType = RigidbodyType2D.Dynamic;
            Box.gravityScale = .15f;
            //BG.SetActive(true);
        }
        else if (collision.CompareTag("spike"))
        {
            Move = false;
            GameManager.Broke = true;
            Ani.SetTrigger("Break");
            Destroy(this, 1);
        }
    }
    private void getBool()
    {

    }
}
