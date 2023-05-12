using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpForce = 5f;
    public Animator animator;
    private bool hasJumped = false;
    private bool isGrounded = false;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundDistance = 0.2f;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (!hasJumped && isGrounded && SwipeManager.swipeUp)
        {
            // Realizar el salto solo si no se ha saltado antes y está en el suelo
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("jumpTrigger");
            hasJumped = true;
        }

        ResetJump();
    }

    public void ResetJump()
    {
        // Restablecer el estado del salto
        if (isGrounded)
        {
            hasJumped = false;
        }
    }
}
