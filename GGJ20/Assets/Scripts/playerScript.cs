using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour 
{

    [SerializeField] private LayerMask platformMask;
    [SerializeField] private LayerMask enemyMask;
    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private BoxCollider2D hitCollider;
    private SpriteRenderer sprite;

    public float movementSpeed = 0.1f;
    public float jumpForce = 30f;

    private float currentTime = 0.0f;

    private float nextHit = 0.0f;

    private List<Weapon> weaponList = new List<Weapon>();
    private Weapon currentWeapon;

    private void OnEnable()
    {
        weaponList.Add(new Weapon("Punch", 1, 50, 0.6f, false));

        currentWeapon = weaponList[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        hitCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        currentTime += Time.deltaTime;

        float hMovement = Input.GetAxis("Horizontal");

        Movement(hMovement);

        Jump();

        Attack();

        // Check if there is an attack spawned then kill it

    }

    private void Movement(float hMovement)
    {
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
    }

    private void Jump()
    {
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

    private void Attack()
    {
        if (Input.GetButton("Fire1") && currentTime > currentWeapon._cooldown)
        {
            nextHit = currentTime + currentWeapon._cooldown;

            if (CheckHit())
            {
                Debug.Log("Here");
            }

            nextHit = nextHit - currentTime;
            currentTime = 0f;
        }
    }

    // TODO: Fixer cette fonction pour que le raycast puisse toucher un gameobject qui est sur le layer enemy (revoie true si c'est le cas)
    private bool CheckHit()
    {
        RaycastHit2D cast = Physics2D.BoxCast(sprite.bounds.center, boxCollider.bounds.size, 0f, ((sprite.flipX) ? Vector2.right : Vector2.left), currentWeapon._range, enemyMask);
        return cast.collider != null;
    }
}
