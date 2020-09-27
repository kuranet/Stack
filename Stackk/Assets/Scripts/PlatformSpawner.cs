using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;

    public void SpawnPlatforn()
    {
        Instantiate(platformPrefab);
    }
}
