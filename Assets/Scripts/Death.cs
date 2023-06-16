using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    [SerializeField] private ParticleSystem exp;


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.tag.Equals("ASTEROID"))
        {
            Instantiate(exp, collision.GetContact(0).point, Quaternion.identity);
            transform.gameObject.SetActive(false);
            Destroy(collision.transform.gameObject);
            FindObjectOfType<Asteroid>().stop();
            FindObjectOfType<Spawner>().stop();
            FindObjectOfType<Spawner>().msg();
            FindObjectOfType<CamFollow>().stop();
        }
    }
}
