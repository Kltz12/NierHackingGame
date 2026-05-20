using UnityEngine;

public class MoveInBetweenPoints : MonoBehaviour
{
    [Header("Waypoints")]
    public Transform[] waypoints;

    [Header("Movement")]
    public float speed = 5f;

    [Header("Wait Time At Waypoints")]
    public float waitTime = 0f;

    [Header("Path Type")]
    public bool loop = true;

    private int currentPoint = 0;
    private int targetPoint = 1;

    private bool forward = true;
    private bool waiting = false;

    private float waitTimer;

    void Start()
    {
        if (waypoints.Length < 2)
            return;

        // Snap to first waypoint
        Vector3 startPos = waypoints[0].position;
        startPos.y = transform.position.y;

        transform.position = startPos;

        currentPoint = 0;
        targetPoint = 1;
    }

    void Update()
    {
        if (waypoints.Length < 2)
            return;

        // Handle waiting
        if (waiting)
        {
            waitTimer -= Time.deltaTime;

            if (waitTimer <= 0f)
            {
                waiting = false;
            }

            return;
        }

        Transform target = waypoints[targetPoint];

        // Keep current Y position
        Vector3 targetPos = new Vector3(
            target.position.x,
            transform.position.y,
            target.position.z
        );

        // Move toward target
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPos,
            speed * Time.deltaTime
        );

        // Reached waypoint
        if (Vector3.Distance(transform.position, targetPos) < 0.001f)
        {
            transform.position = targetPos;

            currentPoint = targetPoint;

            // Start wait timer
            waiting = true;
            waitTimer = waitTime;

            // LOOP MODE
            if (loop)
            {
                targetPoint++;

                if (targetPoint >= waypoints.Length)
                {
                    targetPoint = 0;
                }
            }
            // PING-PONG MODE
            else
            {
                if (forward)
                {
                    if (currentPoint >= waypoints.Length - 1)
                    {
                        forward = false;
                        targetPoint = currentPoint - 1;
                    }
                    else
                    {
                        targetPoint = currentPoint + 1;
                    }
                }
                else
                {
                    if (currentPoint <= 0)
                    {
                        forward = true;
                        targetPoint = currentPoint + 1;
                    }
                    else
                    {
                        targetPoint = currentPoint - 1;
                    }
                }
            }
        }
    }
}
