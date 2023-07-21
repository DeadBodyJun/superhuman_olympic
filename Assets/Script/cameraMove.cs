using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public RaceGameManager race;
    public Transform player;  // ����ٴ� �÷��̾��� Transform ������Ʈ

    public Vector3 offset = new Vector3(1f, 5, -5f);  // ī�޶�� �÷��̾� ���� �ʱ� ������
    //ī�޶� ���� ��ũ��Ʈ ������ ���� 0f, 5, -10f ���� 1f, 5, -5f�� ����(�ӽ�)

    private void Start()
    {
        GameObject obj = GameObject.Find("Slime_01");
        if (obj != null)
        {
            race = obj.GetComponent<RaceGameManager>();
        }

    }
        void LateUpdate()
        {
          // �÷��̾� ��ġ�� ���� ī�޶� �̵���Ŵ
          transform.position = offset + player.position;
          if(race.Speed >= 500)
          {
            this.gameObject.GetComponent<Camera>().fieldOfView -=1;
            if(this.gameObject.GetComponent<Camera>().fieldOfView <=45)
            {
                this.gameObject.GetComponent<Camera>().fieldOfView = 30;
            }
          }
        
        }
}
/*
 ī�޶� ��Ŀ�� �������ϴ°� �������� �ֵ�� ���� ����ٰ� �ϴ¹� ����д�

main camera ���̾��Űâ���� addComponent���� camera filter pack�̶�� �����ִ� �ű⼭ ī�޶� ȿ���� �����ؼ� �����ϳ�.
�츮�� ī�޶� ���� �ʿ��ϱ⋚���� blur ��� �������� ����ؼ� �ִ��� �ӵ����� ������.
���������� ������� race.speed���� �޾Ƽ� this.gameObject.GetComponent<�ʳװ� �߰��� ��ũ��Ʈ>() �ؼ� ����ٰ� ��ó�� ����
���� ������ �����ڵ� �ۼ� ���´ϱ� ���� �غ���

if(race.Speed > 500)
{
     this.gameObject.GetComponent<Focus>().Eyes = 30;
}
�̷������� �ʳװ� ����������� ���� �����ͼ� ���ڷ� �����ϸ�ȴ� ����?
������ �̰� ���� �밡�ٶ� �������̼� �ؾ� ���ϴ�.

�̰� ��ó���� ī�޶� fov�� �ǵ帮�� �ڵ�� ���� ���� �ۼ��؇J�� �̰ɷ� �����غ�
����
 */