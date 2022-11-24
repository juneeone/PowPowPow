using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Bridge : MonoBehaviour
{
    public GameObject Bridge;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="BOAT")
        {
            Destroy(Bridge,0);
        }
    }
}
