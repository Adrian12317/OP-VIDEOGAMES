using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AddKey : MonoBehaviour
{
    public Image image;
    public Sprite keyAdded;
    public Sprite keyRemove;
    public int keys;

    public void AddKeyUI(){
        image.sprite = keyAdded;
        keys++;
    }

    public void RemoveKeyUI(){
        image.sprite = keyRemove;
    }

    public void RemoveKey(){
        if(keys < 0){return;}
        RemoveKeyUI();
        keys--;
    }

    public void ResetKeys(){
        if(keys != 0){
            keys = 0;
            RemoveKeyUI();
        }else{
            return;
        }
    }
}
