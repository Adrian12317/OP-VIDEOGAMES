using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagCheckpoint : MonoBehaviour
{
    public Animator animator;
    protected void OnTriggerEnter2D(Collider2D other){
        Debug.Log("Flag Collision!");
        animator.SetBool("Flag", true);
        // LevelManager.Ins.AddCoins();
        // GameObject.Destroy(this.gameObject);
    }
}
