using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyControl : MonoBehaviour
{
    NavMeshAgent AI;
    public Transform finishObject;
    public float distance =0;
    private Vector3 startPoint;

    private void Awake()
    {
        startPoint = gameObject.transform.position;
    }
    void Start()
    {
        AI = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        AI.SetDestination(finishObject.position);
        distance=Vector3.Distance(finishObject.position, transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="obs")
        {
            transform.position = startPoint;
        }
        else if (other.gameObject.tag=="enemyFinish")
        {
            //AI.isStopped = true;
            //ic ice girip playeri itiyolar hos olmuyor.
            Destroy(gameObject);
        }
    }
}
