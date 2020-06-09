using System.Security.Cryptography;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Microsoft.Win32.SafeHandles;
using UnityEngine;

public class WormController : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode jumpKey;
    public KeyCode fowardKey;
    public KeyCode backKey;
    public KeyCode shootkey;
    public Rigidbody rigid;
    public Vector3 vecJump;
    public Vector3 vecForward;
    public Vector3 shootSpeed;
    public GameObject projectile;
    public GameObject spawnPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            // void OnTriggerEnter(Collider other)
            // {

            // }
            Debug.Log("Jump wurde gedrückt");
            rigid.AddForce(vecJump);
        }

        if (Input.GetKey(fowardKey))
        {

            Debug.Log("Fowaerts wurde gedrückt");
            rigid.AddForce(vecForward);
        }

        if (Input.GetKey(backKey))
        {
            Debug.Log("Back wurde gedrückt");
            rigid.AddForce(-vecForward);
        }

        if (Input.GetKeyDown(shootkey))
        {
            Debug.Log("PewPew");

            GameObject clone = Instantiate(projectile, spawnPosition.transform.position, Quaternion.identity);
            Rigidbody rigid = clone.GetComponent<Rigidbody>();
            rigid.AddForce(shootSpeed);
        }

    }

}