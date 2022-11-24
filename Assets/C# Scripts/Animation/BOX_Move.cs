using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX_Move : MonoBehaviour
{
    //박스 속도
    public float box_speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 22.0f); //10초 뒤 파괴
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(box_speed * Time.deltaTime, 0, 0);  //x좌표로 이동
    }
}
