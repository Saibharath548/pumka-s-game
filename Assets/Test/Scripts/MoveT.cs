using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class MoveT : MonoBehaviour
{ 
    public static MoveT instance;
    private Transform T1;
    private SpriteRenderer sR;
    public Sprite HardS;
    public Sprite HardD;
    private Rigidbody2D rb;
    private bool Super;
    private int noofCH;
    private int maxH = 3;

    private float xInput;
    [SerializeField] private float speed;
    public static bool Harden = false;
    // Start is called before the first frame update
    void Start()
    {
        sR = GetComponent<SpriteRenderer>();
        instance = this;
        rb = GetComponent<Rigidbody2D>();
        T1 = GetComponent<Transform>();  
        noofCH = maxH;
    }

    // Update is called once per frame  
    void Update()
    {
        Hardening();
        xInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        
        if(Harden)
        {
            sR.sprite = HardS;
            StartCoroutine(hard());
        }
        if( Super )
        {
            spawnerT.obstacleSpeed = 5;
            cloud.Speed = speed * 5;
        }
    }

    private void Hardening()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && havePower())
        {
            Harden = true;
        }
        
    }
    public bool havePower()
    {
        if(noofCH <= 0)
            return false;

        noofCH--;
        return true;
    }
    IEnumerator hard()
    {
        yield return new WaitForSeconds(5);
        Harden = false;
        sR.sprite = HardD;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike"))
        {
            Destroy(this.gameObject);
        }
        if(collision.CompareTag("Hard"))
        {
            noofCH = maxH;
        }
        if(collision.CompareTag("Super"))
        {
            Super = true;
        }
    }
    
}
