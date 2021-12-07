using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{

    public GameObject playerTransform;

    public NavMeshAgent navMeshAgent;

    Vector3 playerVector;
     
    void Update()
    {
        playerVector = playerTransform.transform.position;
        navMeshAgent.SetDestination(playerVector);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Destroy(other.gameObject);
        }
        else if (other.tag  == "Bullet")
        {
            Destroy(gameObject);
        }
    }

}
