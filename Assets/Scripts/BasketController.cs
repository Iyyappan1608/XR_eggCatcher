using UnityEngine;

public class BasketController : MonoBehaviour
{
    [Tooltip("How fast the basket moves left and right.")]
    [SerializeField] private float speed = 15f;

    private Camera mainCamera;
    private float screenBoundsX;

    void Start()
    {
        // We get the camera once here, which is more efficient than getting it every frame.
        mainCamera = Camera.main;

        // Calculate the world-space coordinate of the screen's edge.
        // This is used to prevent the basket from moving off-screen.
        Vector3 rightEdge = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, -mainCamera.transform.position.z));
        screenBoundsX = rightEdge.x;
    }

    void Update()
    {
        // Get input from the A/D keys or Left/Right arrow keys.
        // The value will be -1, 0, or 1.
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate the movement amount for this frame.
        Vector3 movement = Vector3.right * horizontalInput * speed * Time.deltaTime;

        // Apply the movement to the basket's current position.
        transform.Translate(movement);

        // --- Keep the Basket On-Screen ---
        // Get the current position.
        Vector3 currentPosition = transform.position;
        // Use Mathf.Clamp to limit the X value between the negative and positive screen bounds.
        currentPosition.x = Mathf.Clamp(currentPosition.x, -screenBoundsX, screenBoundsX);
        // Apply the clamped position back to the basket.
        transform.position = currentPosition;
    }
}