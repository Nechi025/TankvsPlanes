using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float acceleration = 10.0f;

    private float currentSpeed = 0.0f;
    private float targetSpeed = 0.0f;

    public Animator animator; 

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        targetSpeed = horizontalInput * moveSpeed;
        currentSpeed = Mathf.Lerp(currentSpeed, targetSpeed, acceleration * Time.deltaTime);

        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));

        Vector3 newPosition = transform.position + new Vector3(currentSpeed * Time.deltaTime, 0f, 0f);

        Bounds spriteBounds = GetComponent<SpriteRenderer>().bounds;

        float clampedX = Mathf.Clamp(newPosition.x, ScreenBounds.Left + spriteBounds.extents.x, ScreenBounds.Right - spriteBounds.extents.x);

        transform.position = new Vector3(clampedX, newPosition.y, newPosition.z);

    }

    public static class ScreenBounds
    {
        public static float Left => Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        public static float Right => Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;
    }
}
