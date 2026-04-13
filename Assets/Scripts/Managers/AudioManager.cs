using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource trueAnswerAS;
    public AudioSource coinAS;
    public AudioSource impactAS;
    public AudioSource explodeAS;

    public void PlayImpactAS()
    {
        if (impactAS != null)
            impactAS.PlayOneShot(impactAS.clip);

    }

    public void PlayExplodeAS()
    {

        if (explodeAS != null)
            explodeAS.PlayOneShot(explodeAS.clip);

    }

    public void StopExplodeASDelayed(float delay)
    {
        Invoke(nameof(StopExplodeAS), delay);   
    }

    void StopExplodeAS()
    {
        if (explodeAS != null)
            explodeAS.Stop();
    }

    public void PlayCoinAS()
    {
        if (coinAS != null)
            coinAS.PlayOneShot(coinAS.clip);
    }

    public void PlayTrueAnswerAS()
    {
        if (trueAnswerAS != null)
            trueAnswerAS.PlayOneShot(trueAnswerAS.clip);
    }
}
