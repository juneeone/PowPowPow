using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOX_Spawner : MonoBehaviour
{
    public GameObject Prefab;
    public float interval;
    IEnumerator Start()
    {
        while (true)
        {
            Instantiate(Prefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
