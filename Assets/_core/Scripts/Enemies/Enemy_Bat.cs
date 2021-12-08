using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Bat : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite hitSprite;
    public Sprite deadSprite;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D _other) {
        if(_other.tag == GameConstant.TAG_BULLET){
            OnHit();
        }
    }

    public void OnHit(){
        if(animator!=null){
            animator.enabled = false;
        }

        spriteRenderer.sprite = hitSprite;

        Invoke("SetDeadAnim", 0.3f);
    }

    private void SetDeadAnim(){
        spriteRenderer.sprite = deadSprite;
        Invoke("Dead", 0.3f);
    }

    private void Dead(){
        gameObject.SetActive(false);
    }

    public void OnReset(){
        if(animator!=null){
            animator.enabled = true;
        }
    }
}
