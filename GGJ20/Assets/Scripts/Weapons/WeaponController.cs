using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public Collider2D collider2D;
    public GameObject gameObject;
    public GameObject gameObjectEn;
    [SerializeField] private int damage;
    private bool range;
    CharacterController characterController;
    CharacterController characterControllerEn;

    // Start is called before the first frame update
    void Start()
    {
        characterController = gameObject.GetComponent<CharacterController>();
        characterControllerEn = gameObjectEn.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        //Debug.Log("okayyy");
        if (col.gameObject.name == "Pnj")
        {
            Debug.Log("okayyy"+ characterControllerEn.life);
            characterControllerEn.life -= damage;

            characterControllerEn.CheckIfDie(col.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log("okayyy");
        if (other.isTrigger != true && other.CompareTag("Pnj"))
        {
            
            Debug.Log("okayyy");
        }
    }

    /*public int receiveDamage(int dmg)
    {

        life -= dmg;
        Debug.Log("my life " + life);
        return life;
    }*/
}
