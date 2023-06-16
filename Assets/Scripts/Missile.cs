
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
        if (!collision.transform.tag.Equals("MISSILE") && !collision.transform.tag.Equals("Player")) { 
            Destroy(collision.gameObject);
            Instantiate(exp, collision.GetContact(0).point, Quaternion.identity);
            Destroy(gameObject);
            FindObjectOfType<Spawner>().incScore();
        }
    }

}
