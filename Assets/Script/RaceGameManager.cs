using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.InputSystem; // 조이스틱 입력값 받기

public class RaceGameManager : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public float PlayerZ;
    public float NpcZ;
    


    // 싱글톤 패턴
    public static RaceGameManager instance;

    // 다른 스크립트에서 playerInput 변수에 접근할 수 있도록 변경합니다.
    public PlayerInput PlayerInput { get; private set; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        PlayerInput = GetComponent<PlayerInput>(); // PlayerInput 컴포넌트를 가져옵니다.
        PlayerInput.SwitchCurrentActionMap("Player"); // "Player"는 InputActionAsset에 정의된 이름입니다.
    }

    private void Start()
    {
        Speed = 0f;

        PlayerZ = Player.GetComponent<Transform>().position.z; //초기 위치 저장
        
    }

    private void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.Space))
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
        */
    }

    private void OnDisable()
    {
        PlayerInput.DeactivateInput(); // PlayerInput 비활성화
    }

    void OnRun()
    {
        if (Input.GetKeyUp(KeyCode.Space) || PlayerInput.currentActionMap["Run"].triggered)
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
        Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, (float)(Speed * Time.deltaTime * 1.1));
        Debug.Log("스킬");
    }
}
