using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;

    public float moveSpeed = 10f;
    public float laneDistance = 2.5f;

    private int currentLane = 1;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // Start in the middle lane
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("isJumping", false);

        // Gather the inputs on which lane we should be
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentLane++;
            if (currentLane > 2)
            {
                currentLane = 2;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentLane--;
            if (currentLane < 0)
            {
                currentLane = 0;
            }
        }

        // Calculate the target position based on the desired lane
        float targetX = (currentLane - 1) * laneDistance;
        targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        // Move the player to the target position
        controller.Move((targetPosition - transform.position + Vector3.forward * moveSpeed * Time.deltaTime) * moveSpeed * Time.deltaTime);

        // Update the Animator parameters based on the player's current state
        float currentSpeed = (transform.position - targetPosition).magnitude / Time.deltaTime;
        //animator.SetFloat("Speed", currentSpeed);

        // Jumping
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //animator.SetTrigger("Jump");
                //animator.SetBool("isJumping", true);
                controller.Move(Vector3.up * 5f);
            }
        }

        // Falling
        if (!controller.isGrounded)
        {
            controller.Move(Vector3.down * Time.deltaTime * 10);
        }
    }
}
