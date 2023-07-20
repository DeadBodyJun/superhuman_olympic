using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public RaceGameManager race;
    public CameraFilterPack_Blur_Focus Focus;           
    public Transform player;                             // ����ٴ� �÷��̾��� Transform ������Ʈ
    public Vector3 offset = new Vector3(0f, 2, -6f);     // ī�޶�� �÷��̾� ���� �ʱ� ������
    public float sum = 64f;                              // focus_Eyes �������� ���� �߻����� ��������� ���� ��
    private void Start()
    {
        GameObject obj = GameObject.Find("Slime_01");
        if (obj != null)
        {
            race = obj.GetComponent<RaceGameManager>();
        }

        GameObject script = GameObject.Find("Main Camera");
        if (script != null)
        {
            Focus = script.GetComponent<CameraFilterPack_Blur_Focus>();
        }
        
    }

    
    void Update()
        {
        // �÷��̾� ��ġ�� ���� ī�޶� �̵���Ŵ
        float y = transform.position.y; //ī�޶� y�� ������
        
        transform.position = new Vector3 (0, y, player.position.z - 3); //ī�޶� x, y�� �����ϰ� z�� ��ġ��ŭ ���ֱ�
        
        if (race.Speed <= 500)                                          // �ӵ� ������ Fov�� ���� ����
        {
            this.gameObject.GetComponent<Camera>().fieldOfView -= 0.02f;
            sum += 0.02f; 
            Focus._Eyes = sum;                                   
            Debug.Log(sum);
            if (this.gameObject.GetComponent<Camera>().fieldOfView <=30)
            {
               this.gameObject.GetComponent<Camera>().fieldOfView = 30;
            }
            if (sum >= 64f)
            {          
                sum = 64f;      
            }
        }

        if (race.Speed <= 800 && race.Speed >= 501)                     // �ӵ� ������ Fov�� ���� ����
        {
            this.gameObject.GetComponent<Camera>().fieldOfView += 0.03f;
            sum -= 0.02f;
            Focus._Eyes = sum;                          
            if (this.gameObject.GetComponent<Camera>().fieldOfView >= 45)
            {
                this.gameObject.GetComponent<Camera>().fieldOfView = 45;
            }       
            if (sum <= 10f)
            {               
                sum = 10f;      //2
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
     this.gameObject.GetComponent<CameraFilterPack_Blur_Focus>()._Eyes = 30;
}
�̷������� �ʳװ� ����������� ���� �����ͼ� ���ڷ� �����ϸ�ȴ� ����?
������ �̰� ���� �밡�ٶ� �������̼� �ؾ� ���ϴ�.

�̰� ��ó���� ī�޶� fov�� �ǵ帮�� �ڵ�� ���� ���� �ۼ��؇J�� �̰ɷ� �����غ�
����
 */