using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICOntroller : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject text;
    [SerializeField] private Text lifeText;

    CharacterController characterController;
    // Start is called before the first frame update
    void Start()
    {
        GameObject thePlayer = GameObject.Find("thePlayer");
        characterController = thePlayer.GetComponent<CharacterController>();
        text = GameObject.Find("LifeText");
        lifeText = text.GetComponent<Text>();
        lifeText.text =  characterController.life.ToString()+" Hp";
        //pauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
