using UnityEngine;

public class GuardianVision : MonoBehaviour
{
    public Transform player;
    public float viewDistance = 8f;
    public float viewAngle = 90f;
    public LayerMask obstacleMask;

    private float detectCooldown = 0.5f;
    private float lastDetectTime = -999f;

    void Update()
    {
        if (player == null) return;
        if (Time.time < lastDetectTime + detectCooldown) return;

        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer < viewDistance)
        {
            float angle = Vector3.Angle(transform.forward, directionToPlayer);

            if (angle < viewAngle / 2f)
            {
                if (!Physics.Raycast(transform.position + Vector3.up, directionToPlayer, distanceToPlayer, obstacleMask))
                {
                    Debug.Log("PLAYER DETECTED!");

                    PlayerController pc = player.GetComponent<PlayerController>();
                    if (pc != null)
                    {
                        pc.Respawn();
                        lastDetectTime = Time.time;
                    }
                }
            }
        }
    }
}