using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public CoinManager coinManager;

    public GateManager gateManager;

    public FXManager fXManager;
    
    public MainMenu mainMenu;
    
    public UIManager uIManager;
    
    
    
    public LevelManager levelManager;
    public PipeManager pipeManager;
    public Bird bird;

    // Bölümü oluþtur
    // Düþmanlarý oluþtur
    // Oyuncuyu resetle; örneðin bölü bittiðinde oyuncu haritada alakasýz bir yerde duruyor olabilir; oyuncuyu haritanýn baþýna getirebilmek için önemli.

   
    public PipeSpawner pipeSpawner;

    [Header("Pipe Settings")]
    
    private float _pipeSpeed = 3f;
    private float _spawnDistance = 8f;
    private float _destroyX = -20f;



    private void Start()
    {
        // uIManager.ShowMainMenu();


        mainMenu.Show();
        uIManager.GameStarted();


        // oyunu baþlat
        /*pipeSpawner.Init(); // sadece baðýmlýlýklarý hazýrla (kamera vs)
        pipeManager.Init(pipeSpawner, _pipeSpeed, _spawnDistance, _destroyX);

        pipeManager.StartRun(); // ilk pipe'ý üret ve sistemi çalýþtýr*/

        coinManager.StartCoinSpawnCoroutine();
    }

    /*public void Win()
    {
        uIManager.LevelCompleted();
    }*/

    // GameOver / Restart gibi eventlerde:
    public void GameOver()
    {
        pipeManager.StopRun();
    }

    public void Restart()
    {
        /*pipeManager.ResetAll();
        pipeManager.StartRun();*/
        gateManager.RestartGateManager();
        bird.RestartBird();
        
    }

    public void OnBirdDestroyed()
    {
        GameOver();      // pipe’larý durdur, inputu kes vb.

        fXManager.PlayBirdDestroyedParticles(bird.transform.position);
       
        //levelManager.RestartLevel();

        uIManager.LevelFailed();

        coinManager.StopCoinSpawnCoroutine();
    }

    




    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

     void RestartLevel()
    {
        levelManager.RestartLevelManager();
        pipeManager.RestartPipeManager();
        bird.RestartBird();
    }*/
}
