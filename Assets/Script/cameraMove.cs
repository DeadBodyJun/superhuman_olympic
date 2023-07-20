using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public RaceGameManager race;
    public CameraFilterPack_Blur_Focus Focus;           
    public Transform player;                             // 따라다닐 플레이어의 Transform 컴포넌트
    public Vector3 offset = new Vector3(0f, 2, -6f);     // 카메라와 플레이어 간의 초기 오프셋
    public float sum = 64f;                              // focus_Eyes 직접사용시 에러 발생으로 간접사용을 위한 값
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
        // 플레이어 위치에 따라 카메라를 이동시킴
        float y = transform.position.y; //카메라 y값 고정용
        
        transform.position = new Vector3 (0, y, player.position.z - 3); //카메라 x, y값 고정하고 z축 위치만큼 힘주기
        
        if (race.Speed <= 500)                                          // 속도 낮을시 Fov와 블러값 조절
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

        if (race.Speed <= 800 && race.Speed >= 501)                     // 속도 높을시 Fov와 블러값 조절
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
 카메라 포커스 렌더링하는거 조절하자 애들아 형이 여기다가 하는법 적어둔다

main camera 하이어라키창가서 addComponent에서 camera filter pack이라고 폴더있다 거기서 카메라 효과를 선택해서 조율하낟.
우리는 카메라 블러가 필요하기떄문에 blur 라는 폴더에서 사용해서 최대한 속도감을 내보자.
가속했을때 어느정도 race.speed값을 받아서 this.gameObject.GetComponent<너네가 추가한 스크립트>() 해서 여기다가 블러처리 하자
형이 간단한 예시코드 작성 할태니까 보고 해보렴

if(race.Speed > 500)
{
     this.gameObject.GetComponent<CameraFilterPack_Blur_Focus>()._Eyes = 30;
}
이런식으로 너네가 가져오고싶은 값을 가져와서 숫자로 조절하면된다 쉽지?
하지만 이게 완전 노가다라서 여러명이서 해야 편하다.

이거 블러처리랑 카메라 fov값 건드리는 코드는 형이 위에 작성해놧어 이걸로 조절해봐
ㅇㅇ
 */