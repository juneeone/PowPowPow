using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Camera : MonoBehaviour
{
    public GameObject player;           //따라다닐 플레이어를 지정


    //플레이어와 카메라와의 거리 조정
    public float offsetX = 0f;
    public float offsetY = 25f;
    public float offsetZ=-35f;

    //카메라 좌표
    Vector3 cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //플레이어의 변하는 좌표를 계속 추적
        cameraPosition.x = player.transform.position.x + offsetX;
        cameraPosition.y = player.transform.position.y + offsetY;
        cameraPosition.z = player.transform.position.z + offsetZ;
    }
}
