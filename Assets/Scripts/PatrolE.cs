using UnityEngine;
using UnityEngine.AI;
using System.Collections;


    public class PatrolE : MonoBehaviour {

        public Transform[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;


        void Start () {
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            //add items into array
            points[0] = GameObject.Find("Waypoint").transform;
            points[1] = GameObject.Find("Waypoint (1)").transform;
            points[2] = GameObject.Find("Waypoint (2)").transform;
            points[3] = GameObject.Find("Waypoint (3)").transform;
            points[4] = GameObject.Find("Waypoint (4)").transform;
            points[5] = GameObject.Find("Waypoint (5)").transform;
            points[6] = GameObject.Find("Waypoint (6)").transform;

            

            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up
            if (points.Length == 0)
                return;

            // Set the agent to go to the currently selected destination.
            agent.destination = points[destPoint].position;

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = Random.Range(0, points.Length);
        }


        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
            if (!agent.pathPending && agent.remainingDistance < 3f)
                GotoNextPoint();
        }
    }