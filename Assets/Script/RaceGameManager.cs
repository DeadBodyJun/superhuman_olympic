using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;


public class RaceGameManager: MonoBehaviour
{
    public GameObject Player;
    public float Speed=0f;
    
    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            //연타하면 속력이 붙음
            Speed += 15f;
            Player.GetComponent<Rigidbody>().AddForce(0,0,Speed*Time.deltaTime*50);
        }
        else
        {
            //연타멈추면 속력이 줄어들음
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Speed * Time.deltaTime);

        }
        //뒤로 안가게 하기위한 처리
        Speed -= (0.5f*Time.deltaTime)*50;
        if(Speed <=0.0f)
        {
            Speed = 0;
        }
    }
}