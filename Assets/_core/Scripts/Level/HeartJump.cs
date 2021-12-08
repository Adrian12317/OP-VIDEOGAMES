using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;
public class HeartJump : MonoBehaviour
{
    public GameObject heart;
    public void Jump(){
        transform.DOJump(LevelManager.Ins.heartsContainer.transform.position, 1, 1, 0.30f).OnComplete(()=>OnHeartJumpComplete());
    }

    public void OnHeartJumpComplete(){
        GameObject.Destroy(heart);
        LevelManager.Ins.player.AddHeart();
        gameObject.SetActive(false);
    }
}
