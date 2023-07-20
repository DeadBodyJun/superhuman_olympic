using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform player;  // 따라다닐 플레이어의 Transform 컴포넌트

    public Vector3 offset = new Vector3(0f, 5f, -10f);  // 카메라와 플레이어 간의 초기 오프셋

    public float smoothSpeed = 0.5f;  // 카메라 이동 스무딩 속도

    private void LateUpdate()
    {
        // 플레이어 위치에 따라 카메라를 이동시킴
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
