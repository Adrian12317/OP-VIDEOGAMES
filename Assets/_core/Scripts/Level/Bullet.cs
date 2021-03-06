using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public float speed;

    private void OnTriggerEnter2D(Collider2D _other) {
        if(_other.tag == GameConstant.TAG_ENEMY || _other.tag == GameConstant.TAG_GROUND){
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        rigidbody2D.velocity = transform.right*speed;
    }
}
