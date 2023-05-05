using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform cameraTarget;
    public Vector3 offset;
    public float rotationAngle = 0f;
    public float verticalAngle = 0f;

    void LateUpdate()
    {
        transform.position = cameraTarget.position + offset;
        transform.LookAt(cameraTarget);
        transform.rotation = Quaternion.Euler(verticalAngle, rotationAngle, 0f) * cameraTarget.rotation;
    }
}
