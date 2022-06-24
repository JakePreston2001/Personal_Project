using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectsLinear : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints;
    [SerializeField] private float movespeed;
    [SerializeField] private int target;
    private bool reverse;

    

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, waypoints[target].position, movespeed * Time.deltaTime);
        if (transform.position == waypoints[target].position)
        {
            if (!reverse)
            {
                target += 1;
            }
            else if (reverse)
            {
                target -= 1;
            }
            if (target == waypoints.Count - 1)
            {
                reverse = true;
            }
            if( target <= 0)
            {
                reverse = false;
            }
        }
    }
}
