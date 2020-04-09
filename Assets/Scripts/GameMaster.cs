using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameMaster : MonoBehaviour
{
    private bool _gameOver;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && _gameOver == true)
        {
            SceneManager.LoadScene(0, LoadSceneMode.Single);
        }
    }

    public void Gameover()
    {
        Debug.Log("Debug:Game_Master::Gameover called");
        _gameOver = true;
    }
        



}

