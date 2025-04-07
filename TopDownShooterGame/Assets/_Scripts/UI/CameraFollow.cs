using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Tilemap tilemap;

    public float smoothSpeed = 0.125f;

    private Vector3 minBounds;
    private Vector3 maxBounds;
    private float camHalfHeight;
    private float camHalfWidth;

    private void Start()
    {
        // Get the bounds of the tilemap
        Bounds tilemapBounds = tilemap.localBounds;
        minBounds = tilemapBounds.min;
        maxBounds = tilemapBounds.max;

        Camera cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = cam.aspect * camHalfHeight;
    }

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 desiredPosition = new Vector3(player.position.x, player.position.y, transform.position.z);

        // Clamp the camera position
        float clampedX = Mathf.Clamp(desiredPosition.x, minBounds.x + camHalfWidth, maxBounds.x - camHalfWidth);
        float clampedY = Mathf.Clamp(desiredPosition.y, minBounds.y + camHalfHeight, maxBounds.y - camHalfHeight);

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, new Vector3(clampedX, clampedY, desiredPosition.z), smoothSpeed);
        transform.position = smoothedPosition;
    }
}
