using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public void OnContinueClick(){
        gameObject.SetActive(false);
        Time.timeScale = 1;
        // LevelManager.Ins.moveJoystick.gameObject.SetActive(true);
        // LevelManager.Ins.jumpButton.gameObject.SetActive(true);
    }

    public void OnLevelSelectClick(){
        LevelManager.Ins.SelectLevel();
        gameObject.SetActive(false);
        Time.timeScale = 1;
        // LevelManager.Ins.moveJoystick.gameObject.SetActive(false);
        // LevelManager.Ins.jumpButton.gameObject.SetActive(false);
    }
}
