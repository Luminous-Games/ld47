﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gonext3 : MonoBehaviour
{
    private LevelManager levelManager;
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            levelManager.FinishLevel();
        }
    }
}
