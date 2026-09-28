using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveDownSpeed = 2f;
    public float horizontalDistance = 2f;
    public float horizontalSpeed = 2f;
    public float destroyBelowCamera = 2f;

    Vector3 startPosition;
    float movementOffset;

    void Start()
    {
        startPosition = transform.position;
        movementOffset = Random.Range(0f, Mathf.PI * 2f);
    }

    void Update()
    {
        float horizontalMovement = Mathf.Sin(
            (Time.time + movementOffset) * horizontalSpeed) * horizontalDistance;

        transform.position = new Vector3(
            startPosition.x + horizontalMovement,
            transform.position.y - moveDownSpeed * Time.deltaTime,
            transform.position.z);

        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            float bottomOfCamera = mainCamera.ViewportToWorldPoint(
                new Vector3(0f, 0f, Mathf.Abs(mainCamera.transform.position.z))).y;

            if (transform.position.y < bottomOfCamera - destroyBelowCamera)
            {
                Destroy(gameObject);
            }
        }
    }
}
