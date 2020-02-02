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
    CharacterController controller;
    private Animator anim;

    public float movementSpeed = 0.1f;
    public float jumpForce = 30f;

    private float currentTime = 0.0f;
    private float currentJumpTime = 0.0f;
    private float jumpCooldown = 0.6f;

    private float nextHit = 0.0f;
    private float nextJump = 0.0f;

    private List<Weapon_Model> weaponList = new List<Weapon_Model>();
    private Weapon_Model currentWeapon;

    public bool isGrounded = false;
    public bool jumpStarted = false;
    public bool hasDoubleJump = true;
    private bool canJump = true;

    private void OnEnable()
    {
        weaponList.Add(new Weapon_Model("Punch", 1, 5, 0.6f, false));
        currentWeapon = weaponList[0];
    }

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        currentTime += Time.deltaTime;
        currentJumpTime += Time.deltaTime;

        float hMovement = Input.GetAxis("Horizontal");

        if (hMovement > 0)
        {
            transform.position += Vector3.right * movementSpeed;
            sprite.flipX = false;
            anim.SetBool("isWalking", true);

        }
        else if (hMovement < 0)
        {
            transform.position += Vector3.left * movementSpeed;
            sprite.flipX = true;
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetButton("Jump") && (IsGrounded()) && canJump /* && currentJumpTime > jumpCooldown */)
        {
            body.AddForce(Vector3.up * jumpForce);
        }

        if (!IsGrounded())
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
        

        if (Input.GetButton("Fire1") && currentTime > currentWeapon._cooldown)
        {
            nextHit = currentTime + currentWeapon._cooldown;

            nextHit = nextHit - currentTime;
            currentTime = 0f;
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D ray = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size / 2, 0f, Vector2.down, 0.5f, platformMask);
        return ray.collider != null;
    }

    private void disableMovement()
    {
        canJump = false;
        StartCoroutine(activateJump());
    }

    IEnumerator activateJump()
    {
        yield return new WaitForSeconds(0.6f);

        canJump = true;
        //isJumping = true;
    }

    void play(string param)
    {
        anim.SetBool(param, true);
    }

    void disableClimbing()
    {
        anim.SetBool("isClimbing", false);
    }

}
