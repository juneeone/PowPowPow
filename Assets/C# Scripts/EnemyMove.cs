using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMove : MonoBehaviour
{
    NavMeshAgent nav;
    GameObject target;
    
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Slime");          //Slime(플레이어) 오브젝트를 타겟으로 지정한다
    }

    // Update is called once per frame
    void Update()
    {
      if(nav.destination!=target.transform.position)        //만약 추적 대상의 위치가 같지 않다면
        {
            nav.SetDestination(target.transform.position);      //추적 대상을 계속해서 추격하며 이동한다
        }
      else
        { nav.SetDestination(transform.position); }
    }
}
