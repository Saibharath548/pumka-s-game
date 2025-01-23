using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveT : MonoBehaviour
{
    public static MoveT instance;
    private Transform T1;
    
    private Rigidbody2D rb;

    private float xInput;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        T1 = GetComponent<Transform>();  
    }

    // Update is called once per frame  
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike"))
        {
            Destroy(this.gameObject);
        }
    }
}
