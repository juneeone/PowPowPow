using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Script : MonoBehaviour
{
    public string SceneToLoad;                      //불러올 씬의 이름

        public void LoadGame()
    {       
        SceneManager.LoadScene(SceneToLoad);
    }
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
