using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.InputSystem; // ���̽�ƽ �Է°� �ޱ�

public class RaceGameManager : MonoBehaviour
{
    public GameObject Player;
    public float Speed;
    public float PlayerZ;
    public float NpcZ;
    


    // �̱��� ����
    public static RaceGameManager instance;

    // �ٸ� ��ũ��Ʈ���� playerInput ������ ������ �� �ֵ��� �����մϴ�.
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

        PlayerInput = GetComponent<PlayerInput>(); // PlayerInput ������Ʈ�� �����ɴϴ�.
        PlayerInput.SwitchCurrentActionMap("Player"); // "Player"�� InputActionAsset�� ���ǵ� �̸��Դϴ�.
    }

    private void Start()
    {
        Speed = 0f;

        PlayerZ = Player.GetComponent<Transform>().position.z; //�ʱ� ��ġ ����
        
    }

    private void Update()
    {
        /*
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //��Ÿ�ϸ� �ӷ��� ����
            Speed += 20f;
            Player.GetComponent<Rigidbody>().AddForce(0, 0, Speed * Time.deltaTime * 50);
        }
        else
        {
            //��Ÿ���߸� �ӷ��� �پ����
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Speed * Time.deltaTime);
        }

        if (Speed >= 800f)
        {
            Speed = 799f;
        }

        //�ڷ� �Ȱ��� �ϱ����� ó��
        Speed -= (0.5f * Time.deltaTime) * 80;

        if (Speed <= 0.0f)
        {
            Speed = 0;
        }
        */
    }

    private void OnDisable()
    {
        PlayerInput.DeactivateInput(); // PlayerInput ��Ȱ��ȭ
    }

    void OnRun()
    {
        if (Input.GetKeyUp(KeyCode.Space) || PlayerInput.currentActionMap["Run"].triggered)
        {
            //��Ÿ�ϸ� �ӷ��� ����
            Speed += 20f;
            Player.GetComponent<Rigidbody>().AddForce(0, 0, Speed * Time.deltaTime * 50);
        }
        else
        {
            //��Ÿ���߸� �ӷ��� �پ����
            Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, Speed * Time.deltaTime);
        }

        if (Speed >= 800f)
        {
            Speed = 799f;
        }

        //�ڷ� �Ȱ��� �ϱ����� ó��
        Speed -= (0.5f * Time.deltaTime) * 80;

        if (Speed <= 0.0f)
        {
            Speed = 0;
        }
    }

    void OnJump()
    {
        Debug.Log("����");
    }

    void OnSkill()
    {
        Player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, (float)(Speed * Time.deltaTime * 1.1));
        Debug.Log("��ų");
    }
}
