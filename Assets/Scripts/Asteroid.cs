using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.XR.WSA.Input;

public class Asteroid : MonoBehaviour
{
    private GameObject player;
    private bool run;

    private void Start()
    {
        run = true;
        player = GameObject.Find("Plane");
    }

    void Update()
    {
        if (run) { 
            if ((player.transform.position.z - transform.position.z) > 10) {
                Destroy(this.gameObject);
                FindObjectOfType<Spawner>().spawn();
            }
        }
    }

    public void stop() {
        run = false;
    }

}
