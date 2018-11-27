using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Set of identifying values which are used to control states in our code
public enum GameState
{
    menu,
    inGame,
    gameOver
}

public class GameManager : MonoBehaviour {

    /*Creating a GameManager class instance so that we can read data from it in other scripts
    Implementing the singleton pattern restricts this class' instantiation to one object, "instance".*/ 
    public static GameManager instance;
    public GameState currentGameState = GameState.menu;

    void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        currentGameState = GameState.menu;
    }

    private void Update()
    {
        //Used GetButton over GetKey so that we can utilize the input manager to customize our inputs later 
       if (Input.GetButtonDown("Start"))
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        PlayerController.instance.StartGame();
        SetGameState(GameState.inGame);
    }
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
    }
    public void ExitToMenu()
    {
        SetGameState(GameState.gameOver);
    }

    void SetGameState (GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            //Set up unity scene for main menu
        }
        else if (newGameState == GameState.inGame)
        {
            //Initialise main game
        }
        else if (newGameState == GameState.gameOver)
        {
            //Set up unity scene for Game Over screen
        }


        currentGameState = newGameState;
    }
}
