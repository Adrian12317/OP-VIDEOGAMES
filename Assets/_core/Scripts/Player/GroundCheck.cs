using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public bool isGrounded = false;
    public SpriteRenderer spriteRender;

    public PlayerMovement playerMovement;

    void Update()
    {
        if(isGrounded){
            spriteRender.color = Color.green;
        }else{
            spriteRender.color = Color.red;
        }
    }

    protected void OnTriggerEnter2D(Collider2D other){
        // isGrounded = other != null && other.tag == GameConstant.TAG_GROUND;
        // if(other.tag != GameConstant.TAG_GROUND){
        //     isGrounded = true;
        //     return;
        // }
        // if(other != null && other.tag == GameConstant.TAG_GROUND){
        //     playerMovement.OnLandEvent();
        // }   
        if(other.tag != null && other.tag == GameConstant.TAG_GROUND){
            isGrounded = true;
        }
        if(other != null && other.tag == GameConstant.TAG_GROUND){
            playerMovement.OnLandEvent();
        }      
        if(other != null && other.tag == GameConstant.TAG_TRAMPOLIN){
            playerMovement.TrampolineJump();
        }     
    }

    protected void OnTriggerExit2D(Collider2D other){
        // if(other.tag != GameConstant.TAG_GROUND){
        //     isGrounded = true;
        //     return;
        // }
        // isGrounded = false;
        if(other.tag == GameConstant.TAG_TRAMPOLIN){
            isGrounded=false;
            return;
        }
        if(other.tag != GameConstant.TAG_GROUND){
            isGrounded = true;
            return;
        }
        isGrounded = false;
    }
}