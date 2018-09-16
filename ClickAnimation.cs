// On click the player moves to the click position

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickAnimation : MonoBehaviour {

    private Animator mAnimator;
    private NavMeshAgent mNavMeshAgent;
    private bool mRunning = false;
	// Use this for initialization
	void Start () {
        mAnimator = GetComponent<Animator>();
        mNavMeshAgent = GetComponent<NavMeshAgent>();
		
	}
	
	// Update is called once per frame
	void Update () {

        // get the mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // get the mouse click position
        // where the mouse pointer hits the mesh collider of the terrain
        if (Input.GetMouseButton(0))
        { 
            if(Physics.Raycast(ray, out hit, 100))
            {
                // if the ray cast has been successful then set the destibnation of nav mesh agent to the hit point 
                mNavMeshAgent.destination = hit.point;
            }
        }
        // if running distance is less than the stopping distance
        if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance)
        {
            // if true player has reach the destination and running is false
            mRunning = false;
        }
        else
        {
            mRunning = true;
        }

        // set the running parameter to the mRunning 
        mAnimator.SetBool("running", mRunning);
	}
}
