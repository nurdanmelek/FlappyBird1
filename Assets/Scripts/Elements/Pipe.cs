using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pipe : MonoBehaviour
{
    public GameObject obstacle1;
    public GameObject obstacle2;

    private void Start()
    {
        if (Random.value < .5f)
        {
            obstacle1.SetActive(false);
        }
        else
        {
            obstacle2.SetActive(false);
        }
    }
}
