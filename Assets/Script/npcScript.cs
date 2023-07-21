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
        // Scene���� RaceGameManager ��ũ��Ʈ�� ã�Ƽ� �����ɴϴ�.
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
            
            int randomValue = Random.Range(18, 26); // 18 �̻� 25 ������ ������ �������� �����մϴ�.
            npcSpeed += randomValue;

            Npc.GetComponent<Rigidbody>().AddForce(0, 0, npcSpeed * Time.deltaTime * 50);
        }
        else
        {
            //��Ÿ���߸� �ӷ��� �پ����
            Npc.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, npcSpeed * Time.deltaTime);
        }

        if (npcSpeed >= 800f)
        {
            npcSpeed = Random.Range(780, 800);
        }

        //�ڷ� �Ȱ��� �ϱ����� ó��
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

            Debug.Log(RaceGameManager.instance.Speed + "�׸���" + npcSpeed);
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
            Debug.Log("����");
            ingTime += Time.deltaTime; // ��� �ð� ����

            Npc.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, (float)(npcSpeed * Time.deltaTime * 0.8));
        }
    }
}
