using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Setup : MonoBehaviour
{
    public GameObject playerSpawnPosition;

    void Start() //Funciones de Unity, se llama automaticamente
    {
        LevelManager.Ins.player.transform.position = playerSpawnPosition.transform.position;
    }
}
