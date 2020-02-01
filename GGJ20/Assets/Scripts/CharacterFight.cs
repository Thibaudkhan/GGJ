using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFight : MonoBehaviour
{
    public GameObject gameObject;
    public Collider2D collider2D;

    private bool isAttacking = false;
    private float attackTimer = 0;
    private float attackDmg = 1;
    // Start is called before the first frame update
    void Start()
    {
        collider2D.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isAttacking)
        {
            isAttacking = true;
            attackTimer = attackDmg;
            collider2D.enabled = true;
        }
        if (isAttacking)
        {
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                isAttacking = false;
                collider2D.enabled = false;
            }
        }
            
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.CompareTag("Pnj"))
        {
            Debug.Log("okayyy");
        }
    }
    

}
