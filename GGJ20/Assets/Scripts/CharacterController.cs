using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] public int life;
    private int savedLife;
    // Start is called before the first frame update
    void Start()
    {
        savedLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        IsDie();
    }

    private void IsDie()
    {
        if (life == 0)
        {
            Debug.Log("Im dead");
            life = savedLife;
        }
    }
}
