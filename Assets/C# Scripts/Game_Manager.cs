using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Manager : MonoBehaviour
{
    public float LimitTime;

    public Text text_Time;
    private float time;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LimitTime -= Time.deltaTime;
        text_Time.text = "제한시간 : " + Mathf.Round(LimitTime);
        
        if (LimitTime<= 0)
        {  
           // time += Time.deltaTime;
        }

    }
}
