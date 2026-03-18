using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float speed;
    
    public Option option1;
    public Option option2;
    public Option option3;
    
    public void StartGate(List<string> turkishWords)
    {
        option1.SetOption(turkishWords[0]);
        option2.SetOption(turkishWords[1]);
        option3.SetOption(turkishWords[2]);
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
