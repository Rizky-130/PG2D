using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    Vector3 movement;
    public ControlScheme controlScheme = ControlScheme.WASD;

    // Update is called once per frame
    void Update()
    {
        float horizontal = controlScheme == ControlScheme.WASD
            ? GetKeyValue(KeyCode.D) - GetKeyValue(KeyCode.A)
            : GetKeyValue(KeyCode.RightArrow) - GetKeyValue(KeyCode.LeftArrow);
        float vertical = controlScheme == ControlScheme.WASD
            ? GetKeyValue(KeyCode.W) - GetKeyValue(KeyCode.S)
            : GetKeyValue(KeyCode.UpArrow) - GetKeyValue(KeyCode.DownArrow);

        movement = new Vector3(horizontal, vertical, 0f).normalized;
    }
    void FixedUpdate()
    {
        transform.position += movement * speed * Time.deltaTime;
        
    }

    float GetKeyValue(KeyCode key)
    {
        return Input.GetKey(key) ? 1f : 0f;
    }

}

public enum ControlScheme
{
    WASD,
    Arrows
}

