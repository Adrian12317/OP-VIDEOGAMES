using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBullet : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float force = 300;
    public GameObject particulas;

    private void OnTriggerEnter2D(Collider2D _other) {
        if(_other.tag == GameConstant.TAG_ENEMY || _other.tag == GameConstant.TAG_GROUND){
            Instantiate(particulas, transform.position, transform.rotation);
            gameObject.SetActive(false);
        }
    }

    void Start()
    {
        rigidbody2D.AddForce(new Vector2(transform.right.x*200,300));
    }
}
