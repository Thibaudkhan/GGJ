using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerScript : MonoBehaviour {

    [SerializeField] private LayerMask platformMask;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject weaponInventory;


    private Rigidbody2D body;
    private BoxCollider2D boxCollider;
    private SpriteRenderer sprite;
    CharacterController controller;
    private Animator anim;

    public float movementSpeed = 0.1f;

    public float jumpForce = 30f;

    public int tempX;

    private float timePassed = 0;

    private float currentTime = 0.0f;
    private float currentJumpTime = 0.0f;
    private float jumpCooldown = 3f;

    private float nextHit = 0.0f;
    private float nextJump = 0.0f;

    private List<Weapon_Model> weaponList = new List<Weapon_Model>();
    public Weapon_Model currentWeapon;

    public bool isGrounded = false;
    public bool jumpStarted = false;
    public bool hasDoubleJump = true;
    private bool canJump = true;

    private string nameCurrentWeapon;

    private GameObject fight;

    private BoxCollider2D boxCollider2D;

    private void OnEnable() {
        weaponList.Add(new Weapon_Model("poing", 1, 1, 0.6f, false));
        currentWeapon = weaponList[0];
        }


    protected EnemyScript enemyScript;
    protected bool enemy_hp_getted = false;

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        }

    // Update is called once per frame
    void Update() {
        controller = GetComponent<CharacterController>();
        }

    // Update is called once per frame
    void FixedUpdate() {
        currentTime += Time.deltaTime;
        currentJumpTime += Time.deltaTime;

        float hMovement = Input.GetAxis("Horizontal");


        if (hMovement > 0) {
            transform.position += Vector3.right * movementSpeed;
            sprite.flipX = false;
            anim.SetBool("isWalking", true);
            }
        else if (hMovement < 0) {
            transform.position += Vector3.left * movementSpeed;
            sprite.flipX = true;
            anim.SetBool("isWalking", true);
            }
        else {
            anim.SetBool("isWalking", false);
            }

        if ((Input.GetButtonDown("Jump") && (IsGrounded()) && canJump) || (Input.GetButtonDown("Jump") && hasDoubleJump)) {
            hasDoubleJump = false;
            body.AddForce(Vector3.up * jumpForce);
            }

        if (!IsGrounded()) {
            anim.SetBool("isWalking", false);
            anim.SetBool("isJumping", true);
            }
        else {
            isGrounded = true;
            hasDoubleJump = true;
            anim.SetBool("isJumping", false);
            }


        if (Input.GetButton("Fire1") && currentTime > currentWeapon._cooldown) {
            nextHit = currentTime + currentWeapon._cooldown;

            }


        if (Input.GetButton("Jump") && isGrounded && !jumpStarted && currentTime > jumpCooldown) {
            isGrounded = false;
            jumpStarted = true;
            nextJump = currentTime + jumpCooldown;
            nextJump = nextJump - currentTime;
            currentTime = 0f;
            body.AddForce(Vector3.up * jumpForce);
            }

        if (!Input.GetButton("Jump") && isGrounded) {
            jumpStarted = false;
            }

        if (jumpStarted) {
            isGrounded = false;
            }


        /*** Combat ***/


        if (Input.GetButton("Fire1") && currentTime > currentWeapon._cooldown) {
            nextHit = currentTime + currentWeapon._cooldown;
            nextHit = nextHit - currentTime;
            currentTime = 0f;


            fight = GameObject.FindGameObjectWithTag(currentWeapon._name);
            boxCollider2D = fight.GetComponent<BoxCollider2D>();
            boxCollider2D.enabled = true;
            boxCollider2D.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            StartCoroutine(disableCollider());
            }


        }


    private bool IsGrounded() {
        RaycastHit2D ray = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size / 2, 0f, Vector2.down, 0.4f, platformMask);
        return ray.collider != null;
        }

    private void disableMovement() {
        canJump = false;
        StartCoroutine(activateJump());
        }

    IEnumerator activateJump() {
        yield return new WaitForSeconds(0.6f);

        canJump = true;
        //isJumping = true;
        }

    void play(string param) {
        anim.SetBool(param, true);
        }

    void disableClimbing() {
        anim.SetBool("isClimbing", false);
        }



    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "Platform") {
            isGrounded = true;
            }
        }
    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Platform") {
            isGrounded = true;
            }

        if (!hasDoubleJump) {
            isGrounded = false;
            }
        else {
            isGrounded = true;
            }
        }

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.CompareTag("Enemy") && Input.GetButton("Fire1")) {
            collision.gameObject.GetComponent<EnemyScript>().CheckIfDie(currentWeapon._damages);
            }

        }

    IEnumerator disableCollider() {
        yield return new WaitForSeconds(currentWeapon._frame_active);
        boxCollider2D.transform.position = new Vector3(-999, 0, 0);
        boxCollider2D.enabled = false;
        }
    }