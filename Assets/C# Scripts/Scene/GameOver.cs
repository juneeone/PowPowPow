using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//게임오버 화면으로 연결
public class GameOver : MonoBehaviour
{
    public string Over_Scene;
    public PlayerControl lifecount;
    
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Game_Over();
        }

      
    }

    void Game_Over()
    {
        SceneManager.LoadScene(Over_Scene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
