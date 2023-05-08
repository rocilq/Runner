using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;    // La posición del objeto a seguir
    public float smoothSpeed = 0.125f;    // La velocidad a la que la cámara sigue al objeto
    public Vector3 offset;    // El desplazamiento de la cámara desde el objeto

    void LateUpdate()
    {
        // Posición deseada de la cámara, solo se modifica en el eje z
        Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);

        // Posición suavizada de la cámara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Asignar la posición suavizada a la cámara
        transform.position = smoothedPosition;

        // Mantener la rotación en los ejes x e y, y fija en el eje z
        transform.rotation = Quaternion.Euler(25f, 0f, 0f);
    }
}
