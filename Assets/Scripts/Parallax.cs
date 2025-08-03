using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float startPos;
    public GameObject cam;
    public float parallaxEffect;

    void Start()
    {
        // Get the starting X position of this layer
        startPos = transform.position.x;
    }

    void Update()
    {
        // Calculate how far the camera has moved from its starting point
        float dist = (cam.transform.position.x * parallaxEffect);

        // Calculate the new position for the layer
        // The further the layer, the slower it moves
        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);
    }
}