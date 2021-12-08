using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootItem : MonoBehaviour
{

    public GameObject lootUiPosition;
    public bool isActive = false;
    public bool isLooted = false;
    public virtual void GiveLoot(){}
    public bool removeAfterLoot = false;
    
    private void OnTriggerEnter2D(Collider2D _other) {
        if (_other.tag != GameConstant.TAG_PLAYER){return;}
        if(isLooted){ return; }

        LevelManager.Ins.lootUI.gameObject.SetActive(true);
        LevelManager.Ins.lootUI.transform.position = lootUiPosition.transform.position;

        isActive = true;
    }

    private void OnTriggerExit2D(Collider2D _other) {
        if (_other.tag != GameConstant.TAG_PLAYER){return;}
        if(isLooted){ return; }
        LevelManager.Ins.lootUI.gameObject.SetActive(false);
        isActive = false;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(!isActive){ return; }
        if(isLooted){ return; }
        if(Input.GetKeyDown(KeyCode.E)){
            GiveLoot();
            isLooted = true;
            LevelManager.Ins.lootUI.gameObject.SetActive(false);

            if(removeAfterLoot){
                gameObject.SetActive(false);
            }
        }
    }
}
