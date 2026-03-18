using System;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public CoinManager coinManager;

    public GateManager gateManager;

    public FXManager fXManager;
    
    public MainMenu mainMenu;
    
    public UIManager uIManager;
    
    public WordsManager wordsManager;
    
    
    
    public LevelManager levelManager;
    public PipeManager pipeManager;
    public Bird bird;

    // B�l�m� olu�tur
    // D��manlar� olu�tur
    // Oyuncuyu resetle; �rne�in b�l� bitti�inde oyuncu haritada alakas�z bir yerde duruyor olabilir; oyuncuyu haritan�n ba��na getirebilmek i�in �nemli.

   
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
        // oyunu ba�lat
    }
    // GameOver / Restart gibi eventlerde:
    public void GameOver()
    {
        pipeManager.StopRun();
    }

    public void RestartLevel()
    {
        pipeSpawner.Init(); // sadece ba��ml�l�klar� haz�rla (kamera vs)
        pipeManager.Init(pipeSpawner, _pipeSpeed, _spawnDistance, _destroyX);

        pipeManager.ResetAll();
        pipeManager.StartRun();
        gateManager.RestartGateManager();
        bird.RestartBird();
        coinManager.StartCoinSpawnCoroutine();
        
        pipeManager.StartRun(); // ilk pipe'� �ret ve sistemi �al��t�r*/

    }

    public void OnBirdDestroyed()
    {
        GameOver();      // pipe�lar� durdur, inputu kes vb.

        fXManager.PlayBirdDestroyedParticles(bird.transform.position);

        uIManager.LevelFailed();

        coinManager.StopCoinSpawnCoroutine();
    }
    public void CreateLevelData()
    {
        wordsManager.SetLevelKeys();
    }
}
