using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Life_Count : MonoBehaviour
{
    Text life;

    public int life_count = 5;

    public int apple_count;
    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        life.text = "APPLE x " + PlayerControl.apple_count.ToString();
    }
}
