using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] public float jumpForce = 1f;
    [SerializeField] public float gravity = -9.81f;

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            if (playerVelocity.y < -2f)
                playerVelocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        move = Vector3.ClampMagnitude(move, 1f);

        if (groundedPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            playerVelocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }

        playerVelocity.y += gravity * Time.deltaTime;

        Vector3 finalMove = move * moveSpeed;
        finalMove.y = playerVelocity.y;

        controller.Move(finalMove * Time.deltaTime);
    }
}
