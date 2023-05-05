using UnityEngine;

public class CurveMaker : MonoBehaviour
{
    public Transform player;
    public float turnAngle = 90f;

    private bool hasCollided = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player") && !hasCollided)
        {
            hasCollided = true;
            player.Rotate(0, turnAngle, 0, Space.Self);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("player") && hasCollided)
        {
            hasCollided = false;
        }
    }
}
