using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Transform target;    // La posici�n del objeto a seguir
    public float smoothSpeed = 0.125f;    // La velocidad a la que la c�mara sigue al objeto
    public Vector3 offset;    // El desplazamiento de la c�mara desde el objeto

    void LateUpdate()
    {
        // Posici�n deseada de la c�mara, solo se modifica en el eje z
        Vector3 desiredPosition = new Vector3(transform.position.x, transform.position.y, target.position.z + offset.z);

        // Posici�n suavizada de la c�mara
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Asignar la posici�n suavizada a la c�mara
        transform.position = smoothedPosition;

        // Mantener la rotaci�n en los ejes x e y, y fija en el eje z
        transform.rotation = Quaternion.Euler(25f, 0f, 0f);
    }
}
