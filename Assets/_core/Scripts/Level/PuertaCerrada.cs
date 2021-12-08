using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaCerrada : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public SpriteRenderer spriteRenderTop;
    public Sprite openDoor; 
    public Sprite openDoorTop;
    public GameObject noKeys;
    public GameObject exitText;
    public bool isLooted = false;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag != GameConstant.TAG_PLAYER){return;}
        if(isLooted){return;}
        if(LevelManager.Ins.addKey.keys < 1 ){
            noKeys.gameObject.SetActive(true);
            return;
        }
        isLooted = true;
        noKeys.gameObject.SetActive(false);
        exitText.gameObject.SetActive(true);
        LevelManager.Ins.addKey.RemoveKey();
        spriteRender.sprite = openDoor;
        spriteRenderTop.sprite = openDoorTop;
        LevelManager.Ins.OnLevelComplete();
    }
}
