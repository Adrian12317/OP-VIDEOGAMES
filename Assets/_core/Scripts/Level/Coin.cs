using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    protected void OnTriggerEnter2D(Collider2D other){
        if(other.tag != GameConstant.TAG_PLAYER){ return; }
        LevelManager.Ins.AddCoins();
        GameObject.Destroy(this.gameObject);
    }
}
