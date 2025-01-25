using System.Collections;
using UnityEngine;

public class bubble : MonoBehaviour
{
    private Transform T1;
    public Rigidbody2D Box;
    public Rigidbody2D Player;
    public CircleCollider2D Bubble;
    public GameObject BG;
    bool inC;
    public static bool Move;
    public static bubble instance;
    public Animator Ani;
    public static int Fuel = 1;
    public static int Hard = 3;
    private bool HardMode = false;
    private bool Super = false;
    public GameObject BubblePS;
    private bool FuelCheck = true;
    // Start is called before the first frame update
    private void Awake()
    {
        Bubble = GetComponent<CircleCollider2D>();
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
        if (Fuel < 0)
        {
            Move = false;
            GameManager.Broke = true;
            Ani.SetTrigger("Break");
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && Hard > 0 && !HardMode)
        {
            StartCoroutine(HardTimer());
        }
        if (HardMode && Move)
        {
            Ani.SetBool("Hard", true);
        }
        else
        {
            Ani.SetBool("Hard", false);
        }
        if (inC)
        {
            //transform.position += new Vector3(0, 1, 0) * Time.deltaTime;
            //transform.localScale -= new Vector3(.1f, .1f, 0) * Time.deltaTime;
            transform.position = Player.transform.position;
            if (Fuel >= 0 && FuelCheck)
            {
                FuelCheck = false;
                StartCoroutine(FuelTimer());
            }
        }
        if (Super)
        {
            StartCoroutine(speedup());
            StartCoroutine(BubbleParticle());
        }
    }
    IEnumerator BubbleParticle()
    {
        BubblePS.SetActive(true);
        yield return new WaitForSeconds(15);
        BubblePS.SetActive(false);

    }
    IEnumerator speedup()
    {
        Ani.SetBool("Super", true);
        Bubble.enabled = false;
        Time.timeScale = 5;
        //spawnerT.obstacleSpeed = 5;
        //cloud.Speed = cloud.Speed * 5;
        yield return new WaitForSeconds(15);
        Ani.SetBool("Super", false);
        Time.timeScale = 1;
        //spawnerT.obstacleSpeed = 1;
        //cloud.Speed /= 5;
        Bubble.enabled = true;
        Super = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player.gravityScale = 0;
            Move = true;
            inC = true;
            movement.instance.transform.position = T1.position;
            //transform.SetParent(movement.instance.transform);
            Box.bodyType = RigidbodyType2D.Dynamic;
            Box.gravityScale = .15f;
            //BG.SetActive(true);
        }
        else if (collision.CompareTag("spike"))
        {
            Move = false;
            GameManager.Broke = true;
            Ani.SetTrigger("Break");
        }
        else if (collision.CompareTag("Bullet"))
        {
            if (HardMode)
            {
                Destroy(collision.gameObject);
            }
            else
            {
                Move = false;
                GameManager.Broke = true;
                Ani.SetTrigger("Break");
            }
        }
        else if (collision.CompareTag("Fuel"))
        {
            GameManager.CollectedH = true;
            Destroy(collision.gameObject);
            Fuel++;
        }
        else if (collision.CompareTag("hard"))
        {
            if (Hard <= 2)
            {
                Destroy(collision.gameObject);
                Hard++;
            }
        }
        if (collision.CompareTag("Super"))
        {
            Super = true;
            Destroy(collision.gameObject);
        }
    }
    IEnumerator FuelTimer()
    {
        yield return new WaitForSeconds(30);
        FuelCheck = true;
        Fuel--;
    }
    IEnumerator HardTimer()
    {
        HardMode = true;
        yield return new WaitForSeconds(5);
        Hard--;
        HardMode = false;
    }
    public void Des()
    {
        Destroy(gameObject, 1);
    }
}
