using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public GameObject shootPosition;
    public GameObject bulletPrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            Shoot();
        }
    }

    public void Shoot(){
        Debug.Log("Disparo");
        Instantiate(bulletPrefab, shootPosition.transform.position, shootPosition.transform.rotation);
    }
}
