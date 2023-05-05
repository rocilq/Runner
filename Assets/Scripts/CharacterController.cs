using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public Transform cameraTarget;

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontal * rotationSpeed * Time.deltaTime);

        // Rotate the CameraTarget in the opposite direction to keep it looking forward.
        cameraTarget.Rotate(Vector3.up, -horizontal * rotationSpeed * Time.deltaTime);
    }
}
