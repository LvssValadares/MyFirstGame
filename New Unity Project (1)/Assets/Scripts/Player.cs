using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    public float jumpForce;

    public bool isJumping;
    public bool doubleJump;

    private Rigidbody2D rig;
    private Animator anim;
    private bool isBlowing;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();  
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Move()
    {
        //Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transform.position += movement * Time.deltaTime * Speed;
        float movement = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movement * Speed, rig.velocity.y);
        if(movement > 0f)
        {
            anim.SetBool("walk",true);
            transform.eulerAngles = new Vector3(0f,0f,0f);
        }
        if(movement < 0f)
        {
            anim.SetBool("walk",true);
            transform.eulerAngles = new Vector3(0f,180f,0f); 
        }
        if(movement == 0f) 
        {
            anim.SetBool("walk",false);
        }
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump")){

            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump",true);
            }
            else 
            {   
                if(doubleJump)
                {
                rig.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                doubleJump = false;
                anim.SetBool("jump",true);
                }
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.layer == 8)
        {
            isJumping = false;
            anim.SetBool("jump",false);
        } 
        if(col.gameObject.layer == 9)
        {
            GameController.instance.ShowGameOver();
            Destroy(this.gameObject);
        }
    }

    void OnCollisionExit2D(Collision2D groundCollision)
    {
        if(groundCollision.gameObject.layer == 8)
        {
            isJumping = true;
        }
    }

}
