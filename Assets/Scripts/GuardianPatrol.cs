using UnityEngine;

public class GuardianPatrol : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    public float reachDistance = 0.2f;

    private int currentWaypointIndex = 0;

    void Update()
    {
        if (waypoints == null || waypoints.Length == 0) return;

        Transform target = waypoints[currentWaypointIndex];

        Vector3 direction = (target.position - transform.position);
        direction.y = 0f;

        if (direction != Vector3.zero)
        {
            transform.forward = direction.normalized;
        }

        transform.position = Vector3.MoveTowards(
            transform.position,
            new Vector3(target.position.x, transform.position.y, target.position.z),
            moveSpeed * Time.deltaTime
        );

        float distance = Vector3.Distance(
            new Vector3(transform.position.x, 0f, transform.position.z),
            new Vector3(target.position.x, 0f, target.position.z)
        );

        if (distance < reachDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        }
    }
}