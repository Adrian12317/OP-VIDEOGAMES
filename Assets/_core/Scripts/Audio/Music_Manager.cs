using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Manager : MonoBehaviour
{
    public static Music_Manager Ins;
    public List<AudioSource> audioList;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake() {
        Ins = this;
    }

    public void PlaySound(int _sound){
        audioList[_sound].Play();
    }
}
