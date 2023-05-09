using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float laneDistance = 2f;
    public int maxLane = 2;

    private int currentLane = 0;

    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Move the player forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Move to the left lane if "left" arrow key is pressed
        if ((Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) && currentLane > -maxLane)
        {
            currentLane--;
            transform.position = new Vector3(currentLane * laneDistance, transform.position.y, transform.position.z);
        }

        // Move to the right lane if "right" arrow key is pressed
        if ((Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) && currentLane < maxLane)
        {
            currentLane++;
            transform.position = new Vector3(currentLane * laneDistance, transform.position.y, transform.position.z);
        
        }
    
        // Slide
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            animator.SetTrigger("slideTrigger");
        }

    }   
}

