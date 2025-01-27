using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    private Transform PlayerPos;
    public InputAction Playercon;
    private Rigidbody2D rb;
    public Animator Ani;
    private SpriteRenderer SR;
    [SerializeField]private float speed;
    Vector2 moveDirection = Vector2.zero;
    public static bool MoveP;

    public static movement instance;
    public Joystick JPlayer;

    private Transform T;

    private void Awake()
    {
        JPlayer = GameObject.FindGameObjectWithTag("Joy").GetComponent<Joystick>();
        MoveP = false;
        PlayerPos = GetComponent<Transform>();
        instance = this;
        Ani = GetComponent<Animator>();
        Ani.SetBool("Broke", false);
        SR = GetComponent<SpriteRenderer>();
    }
    private void OnEnable()
    {
        Playercon.Enable();
    }
    private void OnDisable()
    {
        Playercon.Disable();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        T = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (MoveP)
        {
            moveDirection = Playercon.ReadValue<Vector2>();
        }
        Ani.SetFloat("Movement", JPlayer.Direction.sqrMagnitude);
        if (JPlayer.Direction.x > 0)
        {
            SR.flipX = true;
        }
        else if (JPlayer.Direction.x < 0)
        {
            SR.flipX = false;
        }

        if (GameManager.Broke)
        {
            //Debug.Log("Broke");
            Ani.SetBool("Broke", true);
            rb.gravityScale = .5f;   
        }
    }

    private void FixedUpdate()
    {
        if (bubble.Move)
        {
            rb.velocity = new Vector2(JPlayer.Direction.x * speed, JPlayer.Direction.y * speed);
            //rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        }
        else
        {
            rb.velocity = new Vector2(JPlayer.Direction.x * speed, rb.velocity.y);
            //rb.velocity = Vector2.zero;
        }
        
    }

}
