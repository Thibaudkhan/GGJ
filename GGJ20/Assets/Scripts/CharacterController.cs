using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public int life = 30;
    public int gold = 50;

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
        CheckIfDie();
    }

    public bool CheckIfDie()
    {
        if(life <= 0)
        {
            life = storedLife;
            isDying = true;
        }
        else
        {
            isDying = false;
        }
        return isDying;
    }
}
