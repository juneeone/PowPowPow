using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    //슬라임의 속도와 점프하는데 모으는 에너지와 점수 및 아이템 카운트 선언
    private float jump_power;           
    public float jump_powerplus = 100.0f;
    public static int apple_count = 0;
    public static int life_count = 5;
    public static int score_count = 0;
    public static float move_speed = 30.0f;
    public float rotation_speed = 0.1f;
    private Key key;


    //오브젝트를 설정할 게이트
    public GameObject Gate_1;
    public GameObject Gate_2;
    public GameObject Gate_Bonus;
    public GameObject Bridge;

    //게이트 통과 점수 설정 및 스테이지 별 슬라임이 장애물 파괴 가능한 기점을 설정하기 위한 사과 갯수
    public float Gate_1_Score;          
    public float Gate_2_Score;
    public float Button_Count = 0;         
    public float Slime_Apple;         

    public float Boat_speed;

    private struct Key
    { // 키 조작 정보 구조체.
        public bool up; 
        public bool down; 
        public bool right; 
        public bool left; 
    };

    private void get_input()
    {
        this.key.up = false;
        this.key.down = false;
        this.key.right = false;
        this.key.left = false;
        // ↑키가 눌렸으면 true를 대입.
        this.key.up |= Input.GetKey(KeyCode.UpArrow);

        // ↓키가 눌렸으면 true를 대입.
        this.key.down |= Input.GetKey(KeyCode.DownArrow);

        // →키가 눌렸으면 true를 대입.
        this.key.right |= Input.GetKey(KeyCode.RightArrow);

        // ←키가 눌렸으면 true를 대입..
        this.key.left |= Input.GetKey(KeyCode.LeftArrow);

    }


    private void Move_control()
    {
        Vector3 move_vector = Vector3.zero;
        Vector3 position = this.transform.position;
        bool is_moved = false;
        
        // 키가 눌렸으면.
        if (this.key.right)
        { 
            move_vector += Vector3.right; // 이동용 벡터를 오른쪽으로 향한다.
            is_moved = true; // '이동 중' 플래그.
        }
        if (this.key.left)
        {
            move_vector += Vector3.left;
            is_moved = true;
        }
        if (this.key.up)
        {
            move_vector += Vector3.forward;
            is_moved = true;
        }
        if (this.key.down)
        {
            move_vector += Vector3.back;
            is_moved = true;
        }

        move_vector.Normalize();
        move_vector *= move_speed * Time.deltaTime;
        position += move_vector;
        position.y = 0.0f;

        if (move_vector.magnitude > 0.01f)
        {
            Quaternion q = Quaternion.LookRotation(move_vector, Vector3.up);
            this.transform.rotation =
                Quaternion.Slerp(this.transform.rotation, q, 0.1f);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        //조작키
        if (Input.GetKey(KeyCode.UpArrow)) {
            this.transform.Translate(Vector3.forward * move_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back * move_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Translate(Vector3.left * move_speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Translate(Vector3.right * move_speed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.Space))                 //점프 버튼=SPACE
        {           
            jump_power += 3 * jump_powerplus * Time.deltaTime;          //누른 시간에 비례하여 점프 높이 증가
        }

        if (Input.GetKeyUp(KeyCode.Space))           //점프 버튼을 떼면 점프한다.
        {
            SFX.Slime_Jump();                               //점프 효과음
            SFX.Play_Jump();
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 5 * jump_power, 0));
            jump_power = 0.0f;
        }

 
    }



    private void OnTriggerEnter(Collider other)
    {
        //만약 닿은 아이템의 태그가 사과라면 획득한 사과 숫자에 따라 크기가 커진다
        if (other.gameObject.tag == "Apple")            
        {
            SFX.Play_Apple();                            //사과 획득 효과음 재생
            Destroy(other.gameObject);
            apple_count += 1;
            score_count += 300;                     //한 프라이빗 안에 전부 들어있어서 위의 스코어로 크기가 계속 커지는 문제 발생(해결: Apple 조건문 내에 투입)

            float growX = transform.localScale.x + (2 * (apple_count+1));
            float growY = transform.localScale.y + (2 * (apple_count+1));
            float growZ = transform.localScale.z + (2 * (apple_count+1));
          
            transform.localScale = new Vector3(growX, growY, growZ);
            Debug.Log("사과:" + apple_count+"점수:"+ score_count);
                   
        }

        if (other.gameObject.tag == "SCORE")             //만약 닿은 아이템의 태그가 점수(큐브)라면
        {
            SFX.Play_Score();                                  //효과음 재생 및 점수획득
            Destroy(other.gameObject);
            score_count += 100;
            Debug.Log("점수:"+score_count);

        }

        if (score_count == Gate_1_Score)         //Gate_1에 기입한 일정 점수이상 획득하면 게이트_1로 지정한 오브젝트 파괴
        {
            SFX.Door_Open();
            Destroy(Gate_1, 0);
            Debug.Log("첫번째 문 파괴!");
        }

        if (score_count == Gate_2_Score)         //위와 동일.
        {
            SFX.Door_Open();
            Destroy(Gate_2, 0);
            Debug.Log("두번째 문 파괴!");
        }

        if(apple_count == 5)
        {
            Destroy(Gate_Bonus, 0);
            Debug.Log("보너스 스테이지가 열렸습니다");
        }

        if (other.gameObject.tag == "GOAL")             // 골인 지점
        {
            SFX.Play_Finish();                                  
            Debug.Log("게임 종료!");

        }

        if (other.gameObject.tag == "FAKEGOAL")
        {
            SFX.FAKE_Finish();
            Destroy(Bridge, 1);
            Destroy(Gate_Bonus, 2);
            Debug.Log("빠아앙~");
        }

        //장애물에 부딪혔을 때, 슬라임이 먹은 사과 갯수가 조건에 비해 적으면 해당 장애물 파괴.
        if (other.gameObject.tag == "Egg")          
        { 
            if(apple_count>Slime_Apple)
            {
                SFX.Play_Egg();
                score_count += 100;
                Destroy(other.gameObject);
                Debug.Log("장애물을 파괴했습니다.");
            }
        }

        //스테이지 02 버튼 관련
        if (other.gameObject.tag == "BUTTON")
        {
            SFX.Button_Push();
            Button_Count += 1;
            Destroy(other.gameObject);
            Debug.Log("활성화된 버튼 수:"+Button_Count);

        }

        if (other.gameObject.tag == "WOOD")
        {
            if (apple_count > 2)
            {
                SFX.Wood_Break();
                Destroy(other.gameObject);
                Debug.Log("나무파괴");
            }
        }

        if (other.gameObject.tag == "IRON")
        {
            if (apple_count > 5)
            {
                SFX.Iron_Break();
                Destroy(other.gameObject);
                Debug.Log("철파괴");
            }
        }

        if (other.gameObject.tag == "ANIMAL")
        {
            if (apple_count > 1)
            {
                SFX.Play_Hit();
                Destroy(other.gameObject);
                Debug.Log("컷");
            }
        }

        if (Button_Count==4)
        {            
            SFX.Wood_Open();
            Destroy(Gate_2, 3);
            Button_Count = 0;
            Debug.Log("버튼을 모두 눌렀습니다. 문이 열립니다.");
        }

        if (other.gameObject.tag=="Enemy")
        {        
            life_count -=1;
            Debug.Log(life_count);
           
        }

    }
}
