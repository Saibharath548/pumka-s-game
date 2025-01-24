using System.Collections;
using UnityEngine;

public class MoveT : MonoBehaviour
{
    public static MoveT instance;
    private Transform T1;
    private SpriteRenderer sR;
    public Sprite HardS;
    public Sprite HardD;
    private Rigidbody2D rb;
    private bool Super = false;
    [SerializeField] private int noofCH;


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
        noofCH = 3;
    }

    // Update is called once per frame  
    void Update()
    {
        Hardening();
        xInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);

        if (Super)
        {
            StartCoroutine(speedup());
        }
    }
    IEnumerator speedup()
    {
        spawnerT.obstacleSpeed = 5;
        cloud.Speed = speed * 5;
        yield return new WaitForSeconds(5);
        Super = false;
    }
    IEnumerator hard()
    {
        sR.sprite = HardS;
        yield return new WaitForSeconds(5);
        Harden = false;
        sR.sprite = HardD;

    }

    private void Hardening()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && havePower())
        {
            StartCoroutine(hard());
            //Harden = true;
        }

    }
    public bool havePower()
    {
        if (noofCH <= 0)
            return false;

        noofCH--;
        return true;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike"))
        {
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("hard"))
        {
            if (noofCH <= 2)
            {
                noofCH++;
            }
        }
        if (collision.CompareTag("Super"))
        {
            Super = true;
            Destroy(collision.gameObject);
        }
    }

}
