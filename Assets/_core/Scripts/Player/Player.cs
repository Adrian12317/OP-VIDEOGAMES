using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public SpriteRenderer spriteRenderer;
    public Sprite spriteHitBlanco;
    public Animator animator;
    public GameObject playerNormalGun;
    public GameObject playerSpecialGun;

    private bool esInmune = false;
    public static int lifes = 3;
    private const int MAX_LIFES = 3;
    
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Enemy"){
            onDamage();
        }
        if(other.tag == "Trampolin"){
            TrampolineJump();
        }
    }

    public void ResetPlayer(){
        lifes = MAX_LIFES;
        playerNormalGun.gameObject.SetActive(false);
        playerSpecialGun.gameObject.SetActive(false);
    }

    public void AddHeart(){
        if(lifes == MAX_LIFES){return;}
        lifes++;
        LevelManager.Ins.OnPlayerAddHeart(lifes);
    }

    public void ActivateGun(bool _specialGun){
        if(_specialGun){
            playerSpecialGun.gameObject.SetActive(true);
            playerNormalGun.gameObject.SetActive(false);
        }else{
            playerSpecialGun.gameObject.SetActive(false);
            playerNormalGun.gameObject.SetActive(true);
        }
    }

    public void DesactiveGuns(){
        playerNormalGun.gameObject.SetActive(false);
        playerSpecialGun.gameObject.SetActive(false);
    }

    private void onDamage(){
        if(esInmune){return;}

        esInmune = true;
        lifes--;
        if(lifes < 0){
            LevelManager.Ins.GameOver();
            return;
        }
        LevelManager.Ins.OnPlayerDamage(lifes);

        //Bloqueo de Movimiento
        playerMovement.BlockMovement(true);
        playerMovement.StopMovement();

        //Aplicar animacion de hit
        animator.enabled = false;
        spriteRenderer.sprite = spriteHitBlanco;

        //Emujar al Player
        playerMovement.DamageForce();

        //Parpadeo
        InvokeRepeating("Parpadeo", 0, 0.3f);

        //Regresar a la normalidad
        Invoke("BackToNormal" , 1);
    }
    private void TrampolineJump(){
        playerMovement.TrampolineJumpForce();
    }

    private void Parpadeo(){
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }

    private void BackToNormal(){
        esInmune = false;
        playerMovement.BlockMovement(false);
        animator.enabled = true;

        CancelInvoke("Parpadeo");
        spriteRenderer.enabled = true;
    }
}
