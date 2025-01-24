using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private Rigidbody2D rb => GetComponent<Rigidbody2D>();
    void Update() => transform.right = rb.velocity;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (MoveT.Harden == false)
        {
            if (collision.CompareTag("Player"))
            {
                Destroy(collision.gameObject);
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
}
