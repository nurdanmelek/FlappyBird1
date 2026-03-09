using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CoinManager : MonoBehaviour
{

    public int coinCount;
    
    public Coin coinPrefab;


    private Coroutine _coinSpawnCoroutine;


    public void StartCoinSpawnCoroutine()
    {
        _coinSpawnCoroutine = StartCoroutine(CoinSpawnCoroutine());
    }


    IEnumerator CoinSpawnCoroutine()
    {
        while (true)
        {
            var spawnTime = UnityEngine.Random.Range(3f, 6f);
            var spawnPos = new Vector3(UnityEngine.Random.Range(-3f, 3f), 4, 0);
            yield return new WaitForSeconds(spawnTime);
            CreateCoinAtPosition(spawnPos);
        }
    }
    public void StopCoinSpawnCoroutine()
    {
        if (_coinSpawnCoroutine != null)
        { 
            StopCoroutine(_coinSpawnCoroutine);
        }
    }

    public void CreateCoinAtPosition(Vector3 pos)    // Herhangi bir pozisyonda bir coin oluþtur. Parametre olarak da bizden bir pozisyon isteyecek
    {
        var newCoin = Instantiate(coinPrefab);
        newCoin.transform.position = pos;

        newCoin.transform.localScale = Vector3.zero;
        newCoin.transform.DOScale(1, .2f).SetEase(Ease.OutBack);

    }

    public void CoinCollected()
    {
        coinCount++;
    }
}


/*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            CreateCoinAtPosition(Vector3.zero);
        }
    }*/