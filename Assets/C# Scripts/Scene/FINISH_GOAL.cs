using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FINISH_GOAL : MonoBehaviour
{
    public string Next_Scene;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Invoke("Next_Game",2.0f);
            
        }
    }

    void Next_Game()
    {
        SceneManager.LoadScene(Next_Scene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
