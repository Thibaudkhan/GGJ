﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public string levelName;
    public string levelName2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SceneManager.LoadScene(levelName);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SceneManager.LoadScene(levelName2);
        }
    }
}
