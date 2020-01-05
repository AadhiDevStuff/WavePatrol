using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour , IDamagable
{
    public int health;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 mousePos;
    public Camera cam;
    public int Health { get; set; }

    void Awake()
    {
        Health = health;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        MoveInput();
    }

    private void FixedUpdate()
    {
        Move();
        RotateTowardsMouse();
    }
    void MoveInput()
    {
        //moveInput
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void RotateTowardsMouse()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //angle calculation;
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        //player rotation
        rb.rotation = angle;
    }

    public void Damage(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
