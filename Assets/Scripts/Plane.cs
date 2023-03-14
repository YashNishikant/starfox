using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private float transformbounds;
    [SerializeField] private float maxTilt;
    [SerializeField] private float tiltSpeed;
    [SerializeField] private float rotatespeed;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private GameObject missile;

    void Start()
    {
    }

    void Update()
    {
        playerMovement();
        missiles();
    }

    void playerMovement()
    {
        transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward*5);

        if (!Input.GetKeyUp(KeyCode.D) || !Input.GetKeyUp(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotatespeed);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < transformbounds)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -maxTilt), Time.deltaTime * rotatespeed);
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(tiltSpeed, 0, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        else if (transform.position.x > transformbounds)
        {
            transform.position = new Vector3(transformbounds, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -transformbounds)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, maxTilt), Time.deltaTime * rotatespeed); 
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(-tiltSpeed, 0, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        else if (transform.position.x < -transformbounds)
        {
            transform.position = new Vector3(-transformbounds, transform.position.y, transform.position.z);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-maxTilt, transform.eulerAngles.y, transform.eulerAngles.z), Time.deltaTime * rotatespeed);
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0, tiltSpeed, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(maxTilt, transform.eulerAngles.y, transform.eulerAngles.z), Time.deltaTime * rotatespeed);
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0, -tiltSpeed, 0) * Time.deltaTime, ForceMode.Impulse);
        }

    }

    void missiles()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(missile, transform.position + new Vector3(1.5f, -0.6f, 0), transform.rotation);
        }
    }

}
