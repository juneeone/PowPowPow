using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Chase : MonoBehaviour
{
    public GameObject Bullet;               //탄환 오브젝트 지정. 프리팹인 Bullet Variant를 지정해라
    public GameObject Enemy;             //탄환을 생성할 적의 위치를 확보하기 위함
       
    private float chase_speed=3.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Chase_Player", 3, 3.0f);           //3초 간격으로 Chase_Player함수 실행
    }

    // Update is called once per frame
    void Update()
    {

    }


    void Chase_Player()
    {
        //[ 적의 x,y,z 포지션 좌표 ]
        float EnemyX = transform.position.x;                
        float EnemyY = transform.position.y;
        float EnemyZ = transform.position.z;

        // [현재 적이 위치한 좌표에서 총알 생성]
        Instantiate(Bullet, new Vector3(EnemyX, EnemyY, EnemyZ), Quaternion.identity);     

    }
}
