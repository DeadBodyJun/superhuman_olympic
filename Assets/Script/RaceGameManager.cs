using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class RaceGameManager: MonoBehaviour
{
    public Transform Player;
    public float Speed=0f;
    
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            Speed += 15f;
            Player.GetComponent<Rigidbody>().AddForce(0,0,Speed*Time.deltaTime*50);
        }
    }
}