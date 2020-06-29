using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Camera cameraEnemy;
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoint = new Transform[5];

    private void Start()
    {
        StartCoroutine(Patrol());
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cameraEnemy.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }
    }

    private IEnumerator Patrol()
    {
        foreach (var item in waypoint)
        {
            navMeshAgent.SetDestination(item.position);
            yield return new WaitForSeconds(10);
        }
    }
}
