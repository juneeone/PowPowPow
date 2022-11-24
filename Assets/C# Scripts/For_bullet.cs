using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class For_bullet : MonoBehaviour
{
    public float countdown;                         //설정할 시간만큼 카운트다운 입력

    public Transform PlayerTr;
    public Rigidbody Bullet_rigid;
    public float turn;
    public float BulletVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //발사된 탄환이 플레이어의 위치를 추적
        Bullet_rigid.velocity = transform.forward * BulletVelocity;
        var BulletTargetRotation = Quaternion.LookRotation(PlayerTr.position + new Vector3(0, 0.8f) - transform.position);
        Bullet_rigid.MoveRotation(Quaternion.RotateTowards(transform.rotation, BulletTargetRotation, turn));

      
    }

   
}
