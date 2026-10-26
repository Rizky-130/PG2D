using Unity.VisualScripting;
using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    public float moveSpeed = 5;
    public float jumpForce = 10;
    public Transform groundCheck;
    public LayerMask groundLayer;
    private bool isGround;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
        
        isGround = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 point = collision.GetContact(0).point;
        Debug.Log($"Collision detected between {gameObject.name} and {collision.gameObject.name} di titik {point}");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log($"{name} Lepas dari {collision.gameObject.name}");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log($"{name} masuk {collider.gameObject.name}");
    }
    private void OnTriggerExit2D(Collider2D other) {
        Debug.Log($"{name} melewati {other.gameObject.name}");    
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, 0.2f);
    }
}
