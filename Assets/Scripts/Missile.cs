using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Rendering;
using UnityEngine;

public class Missile : MonoBehaviour
{
    [SerializeField] private GameObject exp;

    private void Start()
    {
        Destroy(gameObject, 10);
    }

    void Update()
    {
        transform.GetComponent<Rigidbody>().AddForce(transform.forward * 5000 * Time.deltaTime) ;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.tag.Equals("MISSILE")) { 
            Destroy(collision.gameObject);
            Instantiate(exp, collision.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
