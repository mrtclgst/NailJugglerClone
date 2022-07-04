using UnityEngine;
using System.Collections;
using DG.Tweening;
using DG;

public class Mover : MonoBehaviour
{
    public static float gameSpeed = 5;
    public static float GameSpeed
    {
        get { return gameSpeed; }
        set { gameSpeed = value; }
    }
    void Update()
    {
        transform.Translate(gameSpeed * Time.deltaTime * Vector3.forward);
    }
    public void EndingForwardMove()
    {
        transform.DOMoveZ(1.1f + transform.position.z, 2f);
        //StartCoroutine(EndingMove());
    }
}