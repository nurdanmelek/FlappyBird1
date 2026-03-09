using DG.Tweening;
using System;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public CoinManager coinManager;


    public SpriteRenderer sprite;

    public int startHealth = 3;

    private int _currentHealth;

    public float minY = -4f;
    public float maxY = 4f;

    public GameDirector gameDirector;

    


    private void OnEnable()
    {
        _currentHealth = startHealth;
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    

    public void GetHit()
    {
        _currentHealth--;     // _currentHealth değişkeninin değerini 1 azalt

        // önce varsa eski tween'leri öldür (üst üste binmesin)
        sprite.transform.DOKill();

        // 🔹 1) Küçük ve hızlı titreşim (çarpma hissi)
        sprite.transform.DOShakePosition(
            duration: 0.50f,
            strength: new Vector3(0.35f, 0.25f, 0f), // 🔴 büyüttük
            vibrato: 25,                            // 🔴 daha keskin
            randomness: 20,                         // 🔴 daha kontrollü
            fadeOut: true
        );

        // 🔹 2) Çok hafif kırmızı flash (isteğe bağlı ama güzel durur)
       // sprite.DOKill();
       // sprite.DOColor(Color.red, 0.06f).SetLoops(2, LoopType.Yoyo);

        if (_currentHealth == 0 )
        {
            DestroyBird();
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Pipe"))
        {
            GetHit();
        }


    }

    private void DestroyBird()
    {
        //gameDirector.GameOver();   // pipe'ları durdurmak vb.
        gameObject.SetActive(false); // kuş “yok olsun”

        gameDirector.OnBirdDestroyed(); // üst seviyeye haber ver


    }

    public void CoinCollected()
    {
        coinManager.CoinCollected();
    }





    /*public void RestartBird()
    {
        print("restartbird");
    }*/
}
