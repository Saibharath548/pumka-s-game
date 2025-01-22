using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
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
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x*speed, rb.velocity.y);
        
    }

}
