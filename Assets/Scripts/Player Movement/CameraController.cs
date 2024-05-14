using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;  // Reference to the player game object
    public float rotationSpeed = 5f; // Speed of camera rotation

    private Vector3 offset; // Offset distance between the player and camera

    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        // Rotate the camera around the player based on mouse input
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        Quaternion rotation = Quaternion.Euler(0f, horizontalInput, 0f);
        offset = rotation * offset;

        // Update the camera's position to be offset from the player's position
        transform.position = player.transform.position + offset;

        // Make the camera look at the player
        transform.LookAt(player.transform.position);
    }
}
