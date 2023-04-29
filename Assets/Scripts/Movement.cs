using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public bool A_held;
    public bool D_held;
    public bool isgrounded;
    public float speed;
    public float jump;
    public float airmultiplier;
    public GameObject groundraycastorigin;
    public float groundraycastlength;
    public Rigidbody2D rb2D;

    private PlayerController _playerController;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
    }
    
    void Update()
    {
        CheckGround();
        if(!_playerController.IsDead)
        {
            Jump();
            CheckButton();
        }
    }
    void FixedUpdate()
    {
        if(!_playerController.IsDead)
        {
            Move();
        }

    }
    public void CheckButton()
    {
        A_held = Input.GetKey(KeyCode.A);
        D_held = Input.GetKey(KeyCode.D);
    }
    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jump);
        }
    }
    public void CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(groundraycastorigin.transform.position, Vector2.down, groundraycastlength);
        if (hit.collider != null)
        {
            isgrounded = true;
        }
        else
        {
            isgrounded = false;
        }
    }
    public void Move()
    {
        if (A_held)
        {
            if (isgrounded)
            {
                rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            }
            else
            {
                rb2D.velocity = new Vector2(-speed / airmultiplier, rb2D.velocity.y);
            }
            transform.localScale = new Vector3(-1f, 1f, 0f);
  
        }
        if (D_held)
        {

            if (isgrounded)
            {
                rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            }
            else
            {
                rb2D.velocity = new Vector2(speed / airmultiplier, rb2D.velocity.y);
            }
            transform.localScale = new Vector3(1f, 1f, 0f);
        }
        if(!D_held && !A_held)
        {
            rb2D.velocity = new Vector2(0f, rb2D.velocity.y);
        }
    }
}
