using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;


public class RaceGameManager: MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    private void Start()
    {
        Speed = 00f;
    }
    private void Update()
    {
       
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //��Ÿ�ϸ� �ӷ��� ����
            Speed += 20f;
            Player.GetComponent<Rigidbody>().AddForce(0,0,Speed*Time.deltaTime*50);
        }
        else
        {
            //��Ÿ���߸� �ӷ��� �پ����
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Speed * Time.deltaTime);

        }
        if(Speed >= 800f)
        {
            Speed = 799f;
        }
        //�ڷ� �Ȱ��� �ϱ����� ó��
        Speed -= (0.5f*Time.deltaTime)*80;
        if(Speed <=0.0f)
        {
            Speed = 0;
        }
    }
}