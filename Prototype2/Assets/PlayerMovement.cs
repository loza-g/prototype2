using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Adjust this value to control the movement speed.
    float vertical, horizontal;
    Rigidbody2D _rigidbody2D;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        _rigidbody2D.velocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }

}