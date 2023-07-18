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
    public Transform objectToMove;  // 이동시킬 오브젝트의 Transform 컴포넌트

    public float moveSpeed = 5f;  // 이동 속도

    private bool isMoving = false;  // 오브젝트가 이동 중인지 여부를 나타내는 변수

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
