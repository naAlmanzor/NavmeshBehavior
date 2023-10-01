using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class LineUpBehavior : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.Find("GoalPost").transform;
        StartCoroutine(waiter());
    }

    IEnumerator waiter()
    {
        int wait_time = Random.Range (0, 20);
		yield return new WaitForSeconds (wait_time); // Waits for random time
        this.GetComponent<WanderingAgent>().enabled = false; //Disables Wandering Behavior
        agent.SetDestination(goal.position);
    }
}
