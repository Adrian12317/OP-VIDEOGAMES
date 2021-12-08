using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public bool isLooted = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != GameConstant.TAG_PLAYER){return;}
        if(LevelManager.Ins.addKey.keys >= 1) {return;}
        if(isLooted){return;}
        LevelManager.Ins.addKey.AddKeyUI();
        isLooted = true;
        GameObject.Destroy(this.gameObject);
    }
}
