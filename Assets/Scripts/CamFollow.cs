using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{

    private Vector3 offset;
    [SerializeField] private GameObject plane;
    private bool run;

    void Start()
    {
        run = true;
        offset = transform.position - plane.transform.position;
    }
    void Update()
    {
        if(run)
            transform.position = plane.transform.position + new Vector3(0,7,-16);
    }
    public void stop()
    {
        run = false;
    }
}
