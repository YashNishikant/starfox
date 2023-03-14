using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private Vector3 offset;
    [SerializeField] private GameObject plane;

    void Start()
    {
        offset = transform.position - plane.transform.position;
    }
    void Update()
    {
        transform.position = plane.transform.position + new Vector3(0,7,-16);
    }
}
