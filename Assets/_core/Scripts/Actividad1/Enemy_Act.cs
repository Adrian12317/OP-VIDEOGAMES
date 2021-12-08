using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int lifesMosca = 2;
    private int lifesAbeja = 2;
    public static Enemy Ins;
    public Animator animatorMosca;
    public Animator animatorAbeja;
    public Sprite spriteHitBlancoMosca;
    public Sprite spriteHitBlancoAbeja;
    public Sprite spriteMoscaMuerta;
    public Sprite spriteAbejaMuerta;
    public SpriteRenderer spriteRendererMosca;
    public SpriteRenderer spriteRendererAbeja;

    private void Awake() {
        Ins = this;
    }
    void Start()
    {
        
    }

    void Update()
    {
    
    }

    public void OnDamageMosca(){

        lifesMosca--;
        if(lifesMosca < 0){
            animatorMosca.enabled = false;
            spriteRendererMosca.sprite = spriteMoscaMuerta;
            return;
        }

        animatorMosca.enabled = false;
        spriteRendererMosca.sprite = spriteHitBlancoMosca;

        Invoke("BackToNormalMosca" , 0.2f);
    }

    public void OnDamageAbeja(){

        lifesAbeja--;
        if(lifesAbeja < 0){
            animatorAbeja.enabled = false;
            spriteRendererAbeja.sprite = spriteAbejaMuerta;
            return;
        }

        animatorAbeja.enabled = false;
        spriteRendererAbeja.sprite = spriteHitBlancoAbeja;

        Invoke("BackToNormalAbjea" , 0.2f);
    }

    private void BackToNormalMosca(){
        animatorMosca.enabled = true;

        spriteRendererMosca.enabled = true;
    }

    private void BackToNormalAbjea(){
        animatorAbeja.enabled = true;

        spriteRendererAbeja.enabled = true;
    }

    public void ResetEnemyMosca(){
        if(lifesMosca < 1){
            lifesMosca = 2;
            spriteRendererMosca.enabled = true;
            animatorMosca.enabled = true;
        }
    }

    public void ResetEnemyAbeja(){
        if(lifesAbeja < 1){
            lifesAbeja = 2;
            spriteRendererAbeja.enabled = true;
            animatorAbeja.enabled = true;
        }
    }
}
