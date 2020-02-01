using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PnjController : MonoBehaviour
{
    public string[] myConversations;

    Dialogue dialogue;
    public GameObject gameObject;

    // Start is called before the first frame update
    void Start()
    {
        dialogue = gameObject.GetComponent<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player" )
        {
            dialogue.ActiveDialogue();
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            dialogue.DisabledDialogue();
        }
    }

}
