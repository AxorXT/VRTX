using UnityEngine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float slideSpeed = 10f; // Velocidad de deslizamiento
    public float slideDuration = 1f; // Duración del deslizamiento
    private float slideTimer = 0f;

    private CharacterController controller;
    private Vector3 velocity;
    private bool isGrounded;
    private bool isSliding = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Deslizamiento
        if (isGrounded && Input.GetKey(KeyCode.LeftControl) && !isSliding)
        {
            isSliding = true;
            slideTimer = slideDuration;
            controller.height = 1; // Baja la altura del CharacterController para deslizar
        }

        if (isSliding)
        {
            slideTimer -= Time.deltaTime;
            controller.Move(move * slideSpeed * Time.deltaTime);
            if (slideTimer <= 0)
            {
                isSliding = false;
                controller.height = 2; // Restablece la altura
            }
        }
        else
        {
            controller.Move(move * moveSpeed * Time.deltaTime);
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpForce * -2f * Physics.gravity.y);
        }

        velocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
