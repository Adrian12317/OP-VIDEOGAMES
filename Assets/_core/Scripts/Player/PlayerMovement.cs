using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    private float horizontalVal;
    public float speed;
    public float jumpForce;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    public GroundCheck groundCheck;
    private bool blockMovement = false;
    public FixedJoystick joystick;

    public void BlockMovement(bool _block){
        blockMovement = _block;
    }

    public void StopMovement(){
        rigidbody2D.velocity = Vector2.zero;
    }

    public void DamageForce(){
        if(facingRight){
            rigidbody2D.AddForce(new Vector2(-50,250));
        }else{
            rigidbody2D.AddForce(new Vector2(50,250));
        }
    }

    void Update()
    {
        if(blockMovement){return;}
        Move();
        Jump();
        Flip();

        animator.SetFloat("Speed", Mathf.Abs(horizontalVal));
    }

    private void Flip(){
        if((horizontalVal < 0 && facingRight) || (horizontalVal > 0 && !facingRight)){
            facingRight = !facingRight;
            // spriteRenderer.flipX = !facingRight;

            transform.Rotate(0,180,0);
        }
    }

    private void Jump(){
        if(!groundCheck.isGrounded){ return; }
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){

            DoJump();
        }
    }

    public void TrampolineJump(){
        animator.SetBool("IsJumping", true);
    }

    public void TrampolineJumpForce(){
        rigidbody2D.AddForce(new Vector2(0,200));
    }

    public void OnLandEvent(){
        animator.SetBool("IsJumping", false);
    }

    private void Move(){
        //-1 = Izquierda
        //1 = Derecha 
        // horizontalVal = joystick.Horizontal;
        horizontalVal = Input.GetAxisRaw("Horizontal"); 

        rigidbody2D.velocity = new Vector2(horizontalVal * speed, rigidbody2D.velocity.y);
    }

    public void OnJumpClick(){
        DoJump();
    }

    public void DoJump(){
        if(!groundCheck.isGrounded){ return; }
        animator.SetBool("IsJumping", true);
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
    }
    
}
