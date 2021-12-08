using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampolin : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite trampolineActive;
    public Sprite trampoline;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != GameConstant.TAG_PLAYER){return;}
        spriteRenderer.sprite = trampolineActive;
        Invoke("BackToNormal" , 1);
    }

    private void BackToNormal(){
        spriteRenderer.sprite = trampoline;
    }
}
