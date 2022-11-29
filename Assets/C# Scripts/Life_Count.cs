using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Life_Count : MonoBehaviour
{
    Text life;

    public int life_count = 5;

    public int apple_count;

    void Start()
    {
        life = GetComponent<Text>();
    }

    //지금까지 획득한 사과 갯수 표기
    void Update()
    {
        life.text = "APPLE x " + PlayerControl.apple_count.ToString();
    }
}
