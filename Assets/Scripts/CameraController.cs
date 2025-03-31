using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Reference to the player GameObject.
    public GameObject player;

    // The distance between the camera and the player.
    public Vector3 offset = new Vector3(0, 10, -10); // Set the desired offset behind and above the player.

    // Start is called before the first frame update.
    void Start()
    {
        // Ensure that the camera starts with the correct offset.
        transform.position = player.transform.position + offset;
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        // Maintain the same offset between the camera and player.
        Vector3 targetPosition = player.transform.position + offset;

        // Set the camera's position based on the player position and offset.
        transform.position = targetPosition;

        // Make the camera look at the player so they remain centered.
        transform.LookAt(player.transform);  // Keep the camera facing the player
    }
}
