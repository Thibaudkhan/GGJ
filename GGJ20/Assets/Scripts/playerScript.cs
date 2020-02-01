using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour 
{

    [SerializeField] private LayerMask platformMask;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;

    public float movementSpeed = 0.1f;
    public float jumpForce = 30f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        float hMovement = Input.GetAxis("Horizontal");

        if (hMovement > 0)
        {
            transform.position += Vector3.right * movementSpeed;
            sprite.flipX = true;

        }
        else if (hMovement < 0)
        {
            transform.position += Vector3.left * movementSpeed;
            sprite.flipX = false;
        }

        if (Input.GetButton("Jump") && IsGrounded())
        {
            body.AddForce(Vector3.up * jumpForce);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D ray = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, platformMask);
        return ray.collider != null;
    }
}
