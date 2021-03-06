﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    public Text scoreText;
    public GameObject gameOverText;
    public bool gameOver = false;
    private int score = 0;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        } else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && Input.GetKey(KeyCode.Space))
        {
            // reload the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        
    }

    public void scoring()
    {
        if (gameOver)
        {
            return;
        }
        
        score++;
        scoreText.text = "Score: " + score.ToString();
    }

    public void playerDied()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }
}
