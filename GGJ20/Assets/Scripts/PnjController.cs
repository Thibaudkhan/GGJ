using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjController : MonoBehaviour
{
    public string[] myConversations;

    Dialogue dialogue;
    public GameObject gameObject;
    public GameObject weaponsInventory;

    Weapon_Model weapon_Model;

    // Start is called before the first frame update
    void Start()
    {
        weapon_Model = weaponsInventory.GetComponent<Weapon_Model>();
        dialogue = gameObject.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player" )
        {
            dialogue.ActiveDialogue();
            Repare();
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            dialogue.DisabledDialogue();
        }
    }

    void Repare()
    {
        Debug.Log("pourquoi");
        //weapon_Model._isBroken = true;
        //Debug.Log(weapon_Model._isBroken + " et le nom "+ weapon_Model._name);
    }
}
