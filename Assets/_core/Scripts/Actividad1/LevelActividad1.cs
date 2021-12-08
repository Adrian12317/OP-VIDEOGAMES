using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelActividad1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DañoMosca(){
        Enemy.Ins.OnDamageMosca();
    }

    public void DañoAbeja(){
        Enemy.Ins.OnDamageAbeja();
    }

    public void ResetMosca(){
        Enemy.Ins.ResetEnemyMosca();
    }

    public void ResetAbeja(){
        Enemy.Ins.ResetEnemyAbeja();
    }
}
