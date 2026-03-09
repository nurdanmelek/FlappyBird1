using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameDirector gameDirector;

    public MainMenu mainMenu;


    public WinUI winUI;

    public LoseUI loseUI;

    public void GameStarted()
    {
       
        winUI.Hide();
        loseUI.Hide();
    }

    public void ShowMainMenu()
    {
        mainMenu.Show();
    }

    public void PlayGameButtonPressed()
    {
        gameDirector.Restart();
    }


    public void LevelCompleted()
    {
        winUI.Show();
    }

    public void LevelFailed()
    {
        // mainMenu.Hide();  olllmuyooor
        
        loseUI.Show();
        
    }

    public void ReStartLevelButtonPressed()
    {
        gameDirector.Restart();

        // gameDirector.levelManager.RestartLevel();
    }


    /*public void RestartButtonPressed()
    {
        gameDirector.Restart();
    }*/
}
