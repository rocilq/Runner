using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 move;
    public float forwardSpeed;
    public float maxSpeed;

    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between tow lanes
    public float sidewaysSpeed = 5.0f;//The speed of moving to the sides

    private Vector3 velocity;

    public Animator animator;

    bool toggle = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Time.timeScale = 1.2f;
    }

    private void FixedUpdate()
    {

        //Increase Speed
        if (toggle)
        {
            toggle = false;
            if (forwardSpeed < maxSpeed)
                forwardSpeed += 0.1f * Time.fixedDeltaTime;
        }
        else
        {
            toggle = true;
            if (Time.timeScale < 2f)
                Time.timeScale += 0.005f * Time.fixedDeltaTime;
        }
    }

    void Update()
    {

        move.z = forwardSpeed;

        if (velocity.y < 0)
            velocity.y = -1f;

        //Gather the inputs on which lane we should be
        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }
        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }


        //Slide
        if (SwipeManager.swipeDown)
            animator.SetTrigger("slideTrigger");


        //Calculate where we should be in the future
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (desiredLane == 0)
            targetPosition += Vector3.left * laneDistance;
        else if (desiredLane == 2)
            targetPosition += Vector3.right * laneDistance;

        //Calculate the position the player should be in
        Vector3 newPosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
        //Move the player to the new position using Lerp
        transform.position = Vector3.Lerp(transform.position, newPosition, sidewaysSpeed * Time.deltaTime);
    }
}
