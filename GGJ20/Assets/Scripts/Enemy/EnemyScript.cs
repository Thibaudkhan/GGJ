using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    [SerializeField] private LayerMask platformMask;

    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 direction;

    private Enemy_Model basic_thug = new Enemy_Model("Peon", 1, 1, 0.6f, 5, "thug", 1, true, 200);


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
        }

    private void FixedUpdate() {
        //MoveToPlayer(movement);
        }

    public int getHP() {
        int hp_thug = this.basic_thug._hp;
        return hp_thug;
    }

    public void CheckIfDie(int damages) {
        basic_thug._hp -= damages;
        Debug.Log("dm + "+ basic_thug._hp);
        if (basic_thug._hp <= 0) {
            Debug.Log("coucou");
            Destroy(this.gameObject);
            }
        //return false;
        }


    public void MoveToPlayer(Vector2 direction) {
        rb.MovePosition((Vector2)transform.position + (direction * basic_thug._speed * Time.deltaTime));
        }

    public void Rest() {
        Debug.Log("I'm not awake");
        }
}
