using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    public bool isLooted = false;
    public HeartJump heartJump;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != GameConstant.TAG_PLAYER){ return; }
        if(Player.lifes == 3){return;}
        if(isLooted){ return; }
        isLooted = true;
        heartJump.Jump();
    }
}
