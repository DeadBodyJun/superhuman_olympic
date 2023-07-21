using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMove : MonoBehaviour
{
    public RaceGameManager race;
    public Transform player;  // 따라다닐 플레이어의 Transform 컴포넌트

    public Vector3 offset = new Vector3(1f, 5, -5f);  // 카메라와 플레이어 간의 초기 오프셋
    //카메라 무브 스크립트 오프셋 값을 0f, 5, -10f 에서 1f, 5, -5f로 변경(임시)

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
          // 플레이어 위치에 따라 카메라를 이동시킴
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
 카메라 포커스 렌더링하는거 조절하자 애들아 형이 여기다가 하는법 적어둔다

main camera 하이어라키창가서 addComponent에서 camera filter pack이라고 폴더있다 거기서 카메라 효과를 선택해서 조율하낟.
우리는 카메라 블러가 필요하기떄문에 blur 라는 폴더에서 사용해서 최대한 속도감을 내보자.
가속했을때 어느정도 race.speed값을 받아서 this.gameObject.GetComponent<너네가 추가한 스크립트>() 해서 여기다가 블러처리 하자
형이 간단한 예시코드 작성 할태니까 보고 해보렴

if(race.Speed > 500)
{
     this.gameObject.GetComponent<Focus>().Eyes = 30;
}
이런식으로 너네가 가져오고싶은 값을 가져와서 숫자로 조절하면된다 쉽지?
하지만 이게 완전 노가다라서 여러명이서 해야 편하다.

이거 블러처리랑 카메라 fov값 건드리는 코드는 형이 위에 작성해놧어 이걸로 조절해봐
ㅇㅇ
 */