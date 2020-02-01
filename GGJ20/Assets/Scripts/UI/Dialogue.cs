using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Dialogue : MonoBehaviour
{
    [SerializeField] private Text conversationText;
    [SerializeField] private GameObject conversationObject;
    private GameObject text;
    private int myRandConv;
    PnjController pnjController;

    private int preValCon;
    private int aftValCon;
    // Start is called before the first frame update
    void Start()
    {
        
        myRandConv =Random.Range(0, 3);
        GameObject thePlayer = GameObject.Find("Pnj");
        pnjController = thePlayer.GetComponent<PnjController>();
        text = GameObject.Find("conversationsText");
    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void ActiveDialogue()
    {
            conversationObject.SetActive(true);
            myRandConv = Random.Range(0, 3);
            conversationText.text = pnjController.myConversations[myRandConv] ;
            Debug.Log("nb" + myRandConv + " text" + conversationText.text);

    }

    public void DisabledDialogue()
    {
        conversationObject.SetActive(false);
    }
}
