using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunLoot : LootItem
{
    public bool specialGun; 
    public override void GiveLoot(){
        LevelManager.Ins.player.ActivateGun(specialGun);
    }
}
