using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    [SerializeField] private float transformbounds_side;
    [SerializeField] private float transformbounds_topbottom;
    [SerializeField] private float maxTilt;
    [SerializeField] private float tiltSpeed;
    [SerializeField] private float rotatespeed;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private GameObject missile;
    [SerializeField] private ParticleSystem exp;

   
    void Update()
    {
        playerMovement();
        missiles();
    }

    void playerMovement()
    {
        transform.parent.GetComponent<Rigidbody>().AddForce(transform.forward * forwardSpeed * 100 * Time.deltaTime);

        if (!Input.GetKeyUp(KeyCode.D) || !Input.GetKeyUp(KeyCode.A))
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.deltaTime * rotatespeed);
        }
        if (Input.GetKey(KeyCode.D) && transform.position.x < transformbounds_side)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -maxTilt), Time.deltaTime * rotatespeed);
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(tiltSpeed, 0, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        else if (transform.position.x > transformbounds_side)
        {
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(-tiltSpeed, 0, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.A) && transform.position.x > -transformbounds_side)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, maxTilt), Time.deltaTime * rotatespeed); 
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(-tiltSpeed, 0, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        else if (transform.position.x < -transformbounds_side)
        {
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(tiltSpeed, 0, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.W) && transform.position.y < transformbounds_topbottom)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-maxTilt, transform.eulerAngles.y, transform.eulerAngles.z), Time.deltaTime * rotatespeed);
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0, tiltSpeed, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        else if (transform.position.y > transformbounds_topbottom)
        {
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0, -tiltSpeed, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.S) && transform.position.y > -transformbounds_topbottom)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(maxTilt, transform.eulerAngles.y, transform.eulerAngles.z), Time.deltaTime * rotatespeed);
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0, -tiltSpeed, 0) * Time.deltaTime, ForceMode.Impulse);
        }
        else if (transform.position.y < -transformbounds_topbottom)
        {
            transform.parent.GetComponent<Rigidbody>().AddForce(new Vector3(0, tiltSpeed, 0) * Time.deltaTime, ForceMode.Impulse);
        }
    }

    void missiles()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(missile, transform.position + new Vector3(2f, -2f, 5), transform.rotation);
            Instantiate(exp, transform.position + new Vector3(2f, -0.5f, 0), transform.rotation);
        }
    }


}
