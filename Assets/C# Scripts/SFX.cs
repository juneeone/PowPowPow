using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//효과음 관리
public class SFX : MonoBehaviour
{
    static AudioSource audiosource;
    public static AudioClip Score;
    public static AudioClip Door;
    public static AudioClip WoodGate;
    public static AudioClip Wood;
    public static AudioClip Iron;
    public static AudioClip Button;
    public static AudioClip Hit;

    public static AudioClip Jump;
    public static AudioClip Slime;

    public static AudioClip Egg;
    public static AudioClip Apple;

    public static AudioClip FAKE;
    public static AudioClip Goal;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        
        Door = Resources.Load<AudioClip>("DoorOpen");                        //문 열리는 효과음
        WoodGate = Resources.Load<AudioClip>("WoodGate_Open");
        Button = Resources.Load<AudioClip>("BUTTON_PUSH");
        Wood = Resources.Load<AudioClip>("Wooden_break");
        Iron = Resources.Load<AudioClip>("Iron_Break");

        Hit = Resources.Load<AudioClip>("Hit");

        Slime = Resources.Load<AudioClip>("Slime_Voice");                       //슬라임의 점프 소리
        Apple = Resources.Load<AudioClip>("Apple_Sound");                      //사과 아이템 획득
        Score = Resources.Load<AudioClip>("SCORE");                                 //점수 스코어
        Jump = Resources.Load<AudioClip>("Jump_Sound");                     //점프 소리

        Egg = Resources.Load<AudioClip>("Egg_Sound");

        FAKE= Resources.Load<AudioClip>("Fixed_Ship_Horn");
        Goal = Resources.Load<AudioClip>("Finish_Star");
    }

    //보석 획득 효과음
    public static void Play_Score()           
    {
        audiosource.PlayOneShot(Score);
    }

    public static void Play_Apple()
    {
        audiosource.PlayOneShot(Apple);
    }

    public static void Play_Egg()
    {
        audiosource.PlayOneShot(Egg);
    }
    public static void Door_Open()
    {
        audiosource.PlayOneShot(Door);
    }

    public static void Play_Hit()
    {
        audiosource.PlayOneShot(Hit);
    }
    public static void Wood_Open()
    {
        audiosource.PlayOneShot(WoodGate);
    }

    public static void Wood_Break()
    {
        audiosource.PlayOneShot(Wood);
    }

    public static void Iron_Break()
    {
        audiosource.PlayOneShot(Iron);
    }

    public static void Button_Push()
    {
        audiosource.PlayOneShot(Button);
    }

    public static void Play_Jump()
    {
        audiosource.PlayOneShot(Jump);
    }

    public static void Slime_Jump()
    {
        audiosource.PlayOneShot(Slime);
    }

    public static void Play_Finish()
    {
        audiosource.PlayOneShot(Goal);
    }

    public static void FAKE_Finish()
    {
        audiosource.PlayOneShot(FAKE);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
