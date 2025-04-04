using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb;

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // stores the player score (how many pickups player has picked)
    private int score;

    // Speed at which the player moves.
    public float speed = 0;

    // Used to display current score
    public TextMeshProUGUI scoreText;
    // Used to display winning message
    public GameObject winTextObject;

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        rb = GetComponent<Rigidbody>();
        // Initialize score
        score = 0;
        SetScoreText();
        // Hide win message when starting
        winTextObject.SetActive(false);

        MusicManager.Instance.PlayMusic("bg");
    }

    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the object the player collided with has the "PickUp" tag.
        if (other.gameObject.CompareTag("PickUp"))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
            // Play collect sound
            SoundManager.Instance.PlaySound3D("collect", other.transform.position);
            // Increase score
            score = score + 1;
            SetScoreText();
        }
    }

    void SetScoreText()
    {
        // Update GUI text
        scoreText.text = "Score: " + score.ToString();
        // Display win message if no more collectibles to pick up
        if (score >= 12)
        {
            winTextObject.SetActive(true);
            SoundManager.Instance.PlaySound2D("win");
            Destroy(GameObject.FindGameObjectWithTag("Enemy"));
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Destroy the current object
            Destroy(gameObject);
            // Update the winText to display "You Lose!"
            winTextObject.gameObject.SetActive(true);
            winTextObject.GetComponent<TextMeshProUGUI>().text = "You Lose!";
            SoundManager.Instance.PlaySound2D("lose");
        }
    }
}