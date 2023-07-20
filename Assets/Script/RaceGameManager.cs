using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.InputSystem; // 조이스틱 입력값 받기


public class RaceGameManager: MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    private void Start()
    {
        Speed = 00f;
    }

    /*
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //연타하면 속력이 붙음
            Speed += 20f;
            Player.GetComponent<Rigidbody>().AddForce(0,0,Speed*Time.deltaTime*50);
        }
        else
        {
            //연타멈추면 속력이 줄어들음
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Speed * Time.deltaTime);

        }
        if(Speed >= 800f)
        {
            Speed = 799f;
        }
        //뒤로 안가게 하기위한 처리
        Speed -= (0.5f*Time.deltaTime)*80;
        if(Speed <=0.0f)
        {
            Speed = 0;
        }
    }
    */

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>(); // PlayerInput 컴포넌트를 가져옵니다.
        playerInput.SwitchCurrentActionMap("Player"); // "Player"는 InputActionAsset에 정의된 이름입니다.
    }

    private void OnDisable()
    {
        playerInput.DeactivateInput(); // PlayerInput 비활성화
    }

    void OnRun()
    {
        if (Input.GetKeyUp(KeyCode.Space) || playerInput.currentActionMap["Run"].triggered)
        {
            //연타하면 속력이 붙음
            Speed += 20f;
            Player.GetComponent<Rigidbody>().AddForce(0, 0, Speed * Time.deltaTime * 50);
        }
        else
        {
            //연타멈추면 속력이 줄어들음
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Speed * Time.deltaTime);
        }

        if (Speed >= 800f)
        {
            Speed = 799f;
        }

        //뒤로 안가게 하기위한 처리
        Speed -= (0.5f * Time.deltaTime) * 80;

        if (Speed <= 0.0f)
        {
            Speed = 0;
        }
    }

    void OnJump()
    {
        Debug.Log("점프");
    }

    void OnSkill()
    {
        Debug.Log("스킬");
    }
}