using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : LootItem
{
    public Animator animator;
    public GameObject plataforma;

    public override void GiveLoot(){
        animator.Play("PalancaActivada");
        plataforma.SetActive(true);
    }
}
