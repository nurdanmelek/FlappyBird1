using System.Collections;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public float spawnInterval;
    public float gateSpawnDistance;

    private Coroutine _gateSpawnCoroutine;

    public Gate gatePrefab;
    public void RestartGateManager()
    {
        _gateSpawnCoroutine = StartCoroutine(GateSpawnCoroutine());
    }

    public void StopGateManager()
    {
        if (_gateSpawnCoroutine != null)
        {
            StopCoroutine(_gateSpawnCoroutine);
        }
    }

    IEnumerator GateSpawnCoroutine()
    {
        while (true) 
        {
            var newGate = Instantiate(gatePrefab, transform);
            newGate.transform.position = Vector3.right * gateSpawnDistance;
            newGate.StartGate();
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
