using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

enum PlayerStaus
{
    idle,Jump
}

public class playerCtrl : MonoBehaviour
{
    public Transform objectToMove;  // �̵���ų ������Ʈ�� Transform ������Ʈ

    public float moveSpeed = 5f;  // �̵� �ӵ�

    private bool isMoving = false;  // ������Ʈ�� �̵� ������ ���θ� ��Ÿ���� ����

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Move();
        }
    }

    private void Move()
    {
      

    }
}
