using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public Transform player;  // ����ٴ� �÷��̾��� Transform ������Ʈ

    public Vector3 offset = new Vector3(0f, 5f, -10f);  // ī�޶�� �÷��̾� ���� �ʱ� ������

    public float smoothSpeed = 0.5f;  // ī�޶� �̵� ������ �ӵ�

    private void LateUpdate()
    {
        // �÷��̾� ��ġ�� ���� ī�޶� �̵���Ŵ
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
