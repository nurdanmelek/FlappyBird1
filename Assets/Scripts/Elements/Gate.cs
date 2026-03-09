using System;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public float speed;
    public void StartGate()
    {
        
    }

    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * speed;
    }
}
