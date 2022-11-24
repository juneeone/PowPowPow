using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 6.0f;                          //플레이어가 움직이는 스피드
    public float jump_power;                   //점프에 작용하는 힘
    private float gravity = -5.81f;                             //플레이어에게 작용할 중력
    public float jump_powerplus = 100.0f;

    private CharacterController controller; //현재 캐릭터가 가지고 있는 컨트롤러 명칭
    private Vector3 Move_Direction;             // 캐릭터의 움직이는 방향
   
    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(controller.isGrounded==false)
        {
            Move_Direction.y += gravity * Time.deltaTime;
        }

        controller.Move(Move_Direction * speed * Time.deltaTime);
    }

    public void MoveTo(Vector3 Direction)       //방향 정보를 Move_Direction에 저장
    {
        Move_Direction = new Vector3(Direction.x, Move_Direction.y, Direction.z);
    }

    public void JumpTo()                                //점프 함수
    {
        if(controller.isGrounded==true)             //만약 땅에 닿아있을 경우. 이는 반복해서 스페이스키를 누르면 공중에서 연속점프 하는 걸 막기 위함임
        {
            jump_power += 3 * jump_powerplus * Time.deltaTime;      //누른시간에 비례하여 점프 높이 증가
         
        }
    }
    public void JumpUp()
    {
        if (controller.isGrounded == true)      //JumpTo와 마찬가지로 연속점프를 방지
        {
            Move_Direction.y = jump_power;                  //jump_power만큼 y축으로 이동         
            jump_power = 3.0f;                                       //점프 후 jump_power를 3.0f로 다시 초기화
        }
    }

    // Start is called before the first frame update 
    void Start() 
    {  
               
    }
       
}
