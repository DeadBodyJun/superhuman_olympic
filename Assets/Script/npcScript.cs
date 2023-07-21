using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcScript : MonoBehaviour
{
    public GameObject Npc;
    public float npcSpeed;
    private RaceGameManager raceGameManager;
    private float ingTime = 0f;
    public float Distance;


    private void Awake()
    {
        // Scene에서 RaceGameManager 스크립트를 찾아서 가져옵니다.
        raceGameManager = FindObjectOfType<RaceGameManager>();
        Debug.Log(Npc.transform.position.z);
        RaceGameManager.instance.NpcZ = Npc.transform.position.z;
        Distance = RaceGameManager.instance.PlayerZ - RaceGameManager.instance.NpcZ;
    }

    private void Update()
    {
        NpcGo();
        NpcDefence();
    }

    void NpcRun()
    {
        if (Input.GetKeyUp(KeyCode.Space) || raceGameManager.PlayerInput.currentActionMap["Run"].triggered)
        {
            
            int randomValue = Random.Range(18, 26); // 18 이상 25 이하의 랜덤한 정수값을 생성합니다.
            npcSpeed += randomValue;

            Npc.GetComponent<Rigidbody>().AddForce(0, 0, npcSpeed * Time.deltaTime * 50);
        }
        else
        {
            //연타멈추면 속력이 줄어들음
            Npc.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, npcSpeed * Time.deltaTime);
        }

        if (npcSpeed >= 800f)
        {
            npcSpeed = Random.Range(780, 800);
        }

        //뒤로 안가게 하기위한 처리
        npcSpeed -= (0.5f * Time.deltaTime) * 80;

        if (npcSpeed <= 0.0f)
        {
            npcSpeed = 0;
        }
    }

    void NpcGo()
    {
        if (Input.GetKeyUp(KeyCode.Space) || raceGameManager.PlayerInput.currentActionMap["Run"].triggered)
        {
            npcSpeed = RaceGameManager.instance.Speed * Random.Range(95, 110) / 100;
            Npc.GetComponent<Rigidbody>().AddForce(0, 0, npcSpeed * Time.deltaTime * 50);

            Debug.Log(RaceGameManager.instance.Speed + "그리고" + npcSpeed);
        }
        if (Distance > 5f)
        {
            while (Distance > 5f)
            {
                npcSpeed = 2000;
            }

            while (Distance < 5f)
            {
                npcSpeed = 0;
            }
        }
    }

    void NpcDefence()
    {
        if (raceGameManager.PlayerInput.currentActionMap["Skill"].triggered)
        {
            Debug.Log("수비");
            ingTime += Time.deltaTime; // 경과 시간 누적

            Npc.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, (float)(npcSpeed * Time.deltaTime * 0.8));
        }
    }
}
