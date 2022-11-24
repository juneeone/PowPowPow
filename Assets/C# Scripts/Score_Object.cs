using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Score_Object : MonoBehaviour
{
    Text scoreLabel;
  

    public int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "SCORE:" + PlayerControl.score_count.ToString();  //"자유 문장" + PlayerControl의 score_count를 가져와 표시
    }
}
