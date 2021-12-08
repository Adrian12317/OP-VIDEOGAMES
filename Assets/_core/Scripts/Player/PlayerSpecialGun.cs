using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecialGun : MonoBehaviour
{
    public GameObject shootPosition;
    public GameObject bombPrefab;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G)){
            Shoot();
        }
    }

    public void Shoot(){
        Instantiate(bombPrefab, shootPosition.transform.position, shootPosition.transform.rotation);
    }
}
