using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveForce = 10f;
    public float jumpForce = 7f;
    public Transform spawnPoint;
    public float fallThreshold = -10f;

    private Rigidbody rb;
    private bool isGrounded;

    private bool isRespawning = false;
    private float respawnCooldown = 0.5f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isRespawning && transform.position.y < fallThreshold)
        {
            Respawn();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !isRespawning)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        if (isRespawning) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0f, moveZ);
        rb.AddForce(movement * moveForce);
    }

    public void Respawn()
{
    if (isRespawning) return;

    isRespawning = true;

    rb.velocity = Vector3.zero;
    rb.angularVelocity = Vector3.zero;

    transform.position = spawnPoint.position + new Vector3(0f, 2f, 0f);
    transform.rotation = spawnPoint.rotation;

    Invoke(nameof(EndRespawn), respawnCooldown);
}
 
    void EndRespawn()
    {
        isRespawning = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}