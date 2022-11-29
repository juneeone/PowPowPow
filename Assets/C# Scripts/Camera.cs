using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;        //추적할 타겟(플레이어)
    public float dist = 10.0f;          //후방거리
    public float height = 5.0f;         //높이
    public float smoothRotate = 5.0f;  

    private Transform tr;

    void Start()
    {
        tr = GetComponent<Transform>();
        
    }

    void FixedUpdate()
    {
        tr.position = target.position - (1 * Vector3.forward * dist) + (Vector3.up * height);
        tr.LookAt(target);
    }
}
