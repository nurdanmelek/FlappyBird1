using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public int CurrentHealth => _currentHealth;

    public HealthUI healthUI;

    private AudioManager _audioManager;
    
    public CoinManager coinManager;
    public WordsManager wordsManager;
    public SpriteRenderer sprite;

    public int startHealth = 3;

    private int _currentHealth;

    public float minY = -4f;
    public float maxY = 4f;

    public GameDirector gameDirector;

    public TextMeshPro questionTMP;
    public string rightAnswer;


    private void Awake()
    {
        _audioManager = gameDirector.audioManager;
    }

    private void OnEnable()
    {
        _currentHealth = startHealth;

       
    }
    
    public void RestartBird()
    {
        gameObject.SetActive(true);
        var keys = new List<int>(wordsManager.currentLevelKeys);
        var selectedKey = keys[Random.Range(0, keys.Count)];
        questionTMP.text = wordsManager.latinWords[selectedKey];
        rightAnswer = wordsManager.turkishWords[selectedKey];
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            GetHit();
        }

        if (collision.CompareTag("Option"))
        {
            if (collision.GetComponent<Option>().currentText == rightAnswer)
            {
                _audioManager.PlayTrueAnswerAS();

                collision.gameObject.SetActive(false);
            }
            else
            {
                GetHit();
            }
        }
    }
    
    public void CoinCollected()
    {
        coinManager.CoinCollected();
        _audioManager.PlayCoinAS(); // 🔊 burada çal
    }

    public void GetHit()
    {
        _currentHealth--;

        if (healthUI != null)
            healthUI.UpdateHealth(_currentHealth);

        if (_currentHealth > 0)
        {
            _audioManager.PlayImpactAS();
        }

        sprite.transform.DOKill();

        sprite.transform.DOShakePosition(
            duration: 0.50f,
            strength: new Vector3(0.25f, 0.15f, 0f),
            vibrato: 25,
            randomness: 20,
            fadeOut: true
        );

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            DestroyBird();
        }
    }
    private void DestroyBird()
    {

    
        _audioManager.PlayExplodeAS();

        //gameDirector.GameOver();   // pipe'ları durdurmak vb.

        gameObject.SetActive(false); // kuş “yok olsun”
        gameDirector.OnBirdDestroyed(); // üst seviyeye haber ver
        
    }


    public void HealOneHeart()
    {
        if (_currentHealth < startHealth)
        {
            _currentHealth++;
            healthUI.UpdateHealth(_currentHealth);
        }
    }
}
