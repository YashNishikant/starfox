using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obs;
    [SerializeField] private int count;
    private int zPos;

    void Start()
    {
        zPos = 10;
        for (int i = 0; i < count; i++) {
            GameObject o = Instantiate(obs, new Vector3(Random.Range(-165, 165), 10, zPos), Quaternion.identity);
            o.transform.localScale = new Vector3(Random.Range(1, 7), 5, 1); 
            zPos += 10;
        }
    }

    void Update()
    {
        
    }
}
