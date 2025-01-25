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

    public static movement instance;

    private Transform T;

    private void Awake()
    {
        PlayerPos = GetComponent<Transform>();
        instance = this;
        Ani = GetComponent<Animator>();
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
        moveDirection = Playercon.ReadValue<Vector2>();
        Ani.SetFloat("Movement", moveDirection.sqrMagnitude);
        if (moveDirection.x > 0)
        {
            SR.flipX = true;
        }
        else if (moveDirection.x < 0)
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
            rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
        }
        else
        {
            rb.velocity = new Vector2(moveDirection.x * speed, rb.velocity.y);
        }
        
    }

}
