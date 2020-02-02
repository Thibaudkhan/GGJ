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

    public float movementSpeed = 0.1f;
    public float jumpForce = 30f;

    public int tempX;

    private float timePassed = 0;

    private float currentTime = 0.0f;
    private float jumpCooldown = 0.6f;

    private float nextHit = 0.0f;
    private float nextJump = 0.0f;

    private List<Weapon_Model> weaponList = new List<Weapon_Model>();
    private Weapon_Model currentWeapon;

    public bool isGrounded = false;
    public bool jumpStarted = false;
    public bool hasDoubleJump = true;

    private string nameCurrentWeapon;

    private GameObject fight;

    private BoxCollider2D boxCollider2D;

    private void OnEnable() {
        weaponList.Add(new Weapon_Model("poing", 1, 5, 0.6f, false));
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
        }

    // Update is called once per frame
    void FixedUpdate() {
        currentTime += Time.deltaTime;

        float hMovement = Input.GetAxis("Horizontal");

        if (hMovement > 0) {
            transform.position += Vector3.right * movementSpeed;
            //sprite.flipX = true;

            }
        else if (hMovement < 0) {
            transform.position += Vector3.left * movementSpeed;
            //sprite.flipX = false;
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


        if (Input.GetKeyDown(KeyCode.T) && currentTime > currentWeapon._cooldown) {
            nextHit = currentTime + currentWeapon._cooldown;
            nextHit = nextHit - currentTime;
            currentTime = 0f;


            fight = GameObject.FindGameObjectWithTag(currentWeapon._name);
            boxCollider2D = fight.GetComponent<BoxCollider2D>();
            
            ActiveFrameBoxCollider(currentWeapon._frame_active);
            boxCollider2D.enabled = true;
            boxCollider2D.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            StartCoroutine(disableCollider());
            }


        }
    private void ActiveFrameBoxCollider(int ActivateFrame) {

        }
    private bool IsGrounded() {
        RaycastHit2D ray = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, 1f, platformMask);
        return ray.collider != null;
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
        if (collision.gameObject.CompareTag("Enemy") && Input.GetKey(KeyCode.T)) {
            Debug.Log("dsfsdf");
            collision.gameObject.GetComponent<EnemyScript>().CheckIfDie(currentWeapon._damages);
            }
        //else
        //{
        //    boxCollider2D = fight.GetComponent<BoxCollider2D>();
        //    boxCollider2D.enabled = false;
        //}
    }       


    //        //Ici tu retires les Hp rajoutes ton enemy
    //        /*Debug.Log(currentEnemy._hp
    //        if(currentEnemy._hp <= 0) {
    //            Destroy(collision.gameObject);
    //            }

    //        //currentEnemy._hp -= currentWeapon._damages;
    //        Debug.Log("Niquesamere "+ currentEnemy._hp);*/
    //        }
    //    }

    IEnumerator disableCollider() {
            yield return new WaitForSeconds(currentWeapon._frame_active);
        Debug.Log("lolol");
            boxCollider2D.transform.position = new Vector3(-999,0,0) ;
            boxCollider2D.enabled = false;
        }
    }