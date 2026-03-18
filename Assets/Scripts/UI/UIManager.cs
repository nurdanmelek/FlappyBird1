using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameDirector gameDirector;

    public MainMenu mainMenu;


    public WinUI winUI;

    public LoseUI loseUI;
    public HintUI hintUI;

    public void GameStarted()
    {
        winUI.Hide();
        loseUI.Hide();
        hintUI.Hide();
    }

    public void ShowMainMenu()
    {
        mainMenu.Show();
    }

    public void PlayGameButtonPressed()
    {
        gameDirector.CreateLevelData();
        hintUI.Show(0);
        //gameDirector.Restart();
    }


    public void LevelCompleted()
    {
        winUI.Show();
    }

    public void LevelFailed()
    {
        // mainMenu.Hide();  olllmuyooor
        
        loseUI.Show(1);
        
    }

    public void ReStartLevelButtonPressed()
    {
        gameDirector.RestartLevel();

        // gameDirector.levelManager.RestartLevel();
    }


    /*public void RestartButtonPressed()
    {
        gameDirector.Restart();
    }*/
    public void HintUIButtonPressed()
    {
        hintUI.Hide();
        gameDirector.RestartLevel();
    }
}
