using System;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public StudyPath path;
    public float speed = 5f;
    public float mass = 5f;
    public bool isLooping = true;

    private float currSpeed;
    private int currPathIndex;
    private float pathLength;
    private Vector3 targetPoint;

    private Vector3 velocity;

    void Start()
    {
        pathLength = path.points.Length;
        currPathIndex = 0;

        velocity = transform.forward;
    }

    void Update()
    {
        currSpeed = speed * Time.deltaTime;
        targetPoint = path.GetPoint(currPathIndex);

        if (Vector3.Distance(transform.position, targetPoint) < path.radius )
        {
            if (currPathIndex < pathLength - 1)
            {
                currPathIndex++;
            }
            else if (isLooping) 
            {
                currPathIndex = 0;
            }
            else
            {
                return;
            }
        }

        if (currPathIndex >= pathLength)
            return;

        if(currPathIndex >= pathLength - 1 && !isLooping)
        {
            velocity += Steer(targetPoint, true);
        }
        else
        {
            velocity += Steer(targetPoint);
        }

        transform.position += velocity;
        transform.rotation = Quaternion.LookRotation(velocity);
    }

    public Vector3 Steer(Vector3 target, bool isFinalPoint = false)
    {
        Vector3 targetDir = target - transform.position;
        float dist = targetDir.magnitude;

        targetDir.Normalize();

        if(isFinalPoint && dist < 10f)
        {
            targetDir *= currSpeed * (dist / 10f);
        }
        else
        {
            targetDir *= currSpeed;
        }

        Vector3 steeringForce = targetDir - velocity;
        Vector3 acceleration = steeringForce / mass;

        return acceleration;
    }
}
