using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int life = 10;
    public int gold = 50;
    public GameObject gameObject;

    private int storedLife;
    private bool isDying = false;

    // Start is called before the first frame update
    void Start()
    {
        storedLife = life ;
    }

    // Update is called once per frame
    void Update()
    {
        //CheckIfDie();
    }

    public bool CheckIfDie(GameObject gameObject)
    {
        if(life <= 0)
        {
            
            isDying = true;
            if (GameObject.FindWithTag("Pnj"))
            {
               // Debug.Log("ntm "+ gameObject);
                Destroy(gameObject);
                life = storedLife;
            }
            else if (GameObject.FindWithTag("Player"))
            {
                life = storedLife;
            }
            
            
        }
        else
        {
            isDying = false;
        }
        return isDying;
    }

    public int receiveDamage(int dmg)
    {
        
        life -= dmg;
        Debug.Log("my life " + life);
        return life;
    }
}
