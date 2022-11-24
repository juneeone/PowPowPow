using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOAT_MOVE : MonoBehaviour
{
    //보트 속도
    public float boat_speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,boat_speed * Time.deltaTime);  //x좌표로 이동
    }
}
