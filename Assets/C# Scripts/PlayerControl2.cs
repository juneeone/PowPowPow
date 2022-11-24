using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl2 : MonoBehaviour
{
    private PlayerMove playermove;                      //PlayerMove 스크립트 사용
    //public int gem_count = 1;

   
    private void Awake()
    {
        playermove = GetComponent<PlayerMove>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        playermove.MoveTo(new Vector3(x, 0, z));

        if (Input.GetKey(KeyCode.Space))         //스페이스키를 누르면 
        {
            playermove.JumpTo();                    //JumpTo(PlayerMove) 함수를 호출
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playermove.JumpUp();
        }
    }

}
