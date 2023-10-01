using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ApproachBehavior : MonoBehaviour
{
    public Transform goal;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        goal = GameObject.Find("GoalPost").transform;
        StartCoroutine(Waiter());
    }

    IEnumerator Waiter()
    {
        int wait_time = Random.Range (10, 20);
		
        // Infinite cycle
        while(true)
        {
            yield return new WaitForSeconds (wait_time);
        
            this.GetComponent<WanderingAgent>().enabled = false; //Disables Wandering Behavior
            this.GetComponent<FleeBehavior>().enabled = false; //Disables Flee Behavior
            agent.SetDestination(goal.position);

            yield return new WaitUntil(() => agent.remainingDistance <= 1f); // Waits till it agent distance is less than equal 1
        
            this.GetComponent<WanderingAgent>().enabled = true; //Enables Wandering Behavior
            this.GetComponent<FleeBehavior>().enabled = true; //Enables Flee Behavior
        }
    }
}
