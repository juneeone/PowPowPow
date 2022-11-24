using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//일정 시간 후 오브젝트가 사라지는 스크립트. Bullet이 발사되고 일정 시간 후 사라지게 하기 위함임

public class Vanish_Object : MonoBehaviour
{
    public float countdown;                         //설정할 시간만큼 카운트다운 입력

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //발사된 탄환이 일정 시간 후 파괴
        countdown -= Time.deltaTime;        //카운트 다운이 초단위로 서서히 감소

        if (countdown <= 0)                         //카운트 다운이 0이 되면 오브젝트 삭제
        {
            Destroy(gameObject, 0);
        }
    }
}
