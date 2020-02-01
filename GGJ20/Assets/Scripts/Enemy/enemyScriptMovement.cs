using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScriptMovement : MonoBehaviour
{

    [SerializeField] private LayerMask platformMask;

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 direction;

    public Enemy_Model basic_thug = new Enemy_Model("Peon", 1, 1, 0.6f, 1, "thug", 1, true, 200);


    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        direction = player.position - transform.position;
        direction.Normalize();
        movement = direction;
        Debug.Log(direction);
        }

    private void FixedUpdate() {
        MoveToPlayer(movement);
        }

    public void MoveToPlayer(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * basic_thug._speed * Time.deltaTime));
        }

    public void Rest() {
        Debug.Log("I'm not awake");
        }
}
