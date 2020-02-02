using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterUI : MonoBehaviour
{
     private GameObject text;
    [SerializeField] private Text lifeText;
    [SerializeField] private Text goldText;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject thePlayer = GameObject.Find("Player");
        characterController = thePlayer.GetComponent<CharacterController>();
        text = GameObject.Find("lifeText");
        //lifeText = text.GetComponent<Text>();
        //lifeText.text = characterController.life.ToString() + " Hp";
        text = GameObject.Find("goldText");
        //goldText = text.GetComponent<Text>();
        //goldText.text = characterController.gold.ToString() + " Po";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
