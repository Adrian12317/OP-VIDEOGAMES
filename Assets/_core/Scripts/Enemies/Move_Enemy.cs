using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class Move_Enemy : MonoBehaviour
{
    public GameObject startPosition;
    public GameObject endPosition;
    public GameObject enemy;
    public float timeAnim;

    // Start is called before the first frame update
    void Start()
    {
        enemy.transform.position = startPosition.transform.position;
        enemy.transform.DOMove(endPosition.transform.position, timeAnim).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
    }

}
