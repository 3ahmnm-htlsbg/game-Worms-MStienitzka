using System.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.Security.Cryptography;
using Microsoft.Win32.SafeHandles;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WormController : MonoBehaviour
{
    // Start is called before the first frame update
    public float particalWait;
    public KeyCode jumpKey;
    public KeyCode fowardKey;
    public KeyCode backKey;
    public KeyCode shootkey;
    public Rigidbody rigid;
    public Vector3 vecJump;
    public Vector3 vecForward;
    public Vector3 vecRotate;
    public Vector3 shootSpeed;
    public GameObject particleFire;

    public GameObject projectile;
    public GameObject spawnPosition;


    private bool viewDirectionRight;


    // Update is called once per frame

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(jumpKey))
        {
            Debug.Log("Jump wurde gedrückt");
            rigid.AddForce(vecJump);
            particleFire.SetActive(true);
        }
        else
        {
            particleFire.SetActive(false);
        }

    }


    void Update()
    {


        if (Input.GetKey(fowardKey))
        {
            //sets rotation, sets bool to true and walks to the right
            transform.eulerAngles = vecRotate;
            viewDirectionRight = true;
            Debug.Log("Fowaerts wurde gedrückt");
            rigid.AddForce(vecForward);
        }

        //sets rotation, sets bool to false and walks to the left
        if (Input.GetKey(backKey))
        {
            transform.eulerAngles = -vecRotate;
            viewDirectionRight = false;
            Debug.Log("Back wurde gedrückt");
            rigid.AddForce(-vecForward);
        }

        //checks if player is lookin to the right and shoots to the right
        if (Input.GetKeyDown(shootkey) & viewDirectionRight)
        {
            Debug.Log("PewPew");
            GameObject clone = Instantiate(projectile, spawnPosition.transform.position, Quaternion.identity);
            Rigidbody rigid = clone.GetComponent<Rigidbody>();
            rigid.AddForce(shootSpeed);
        }

        // checks if player is lookin to the left and shoots to the left
        if (Input.GetKeyDown(shootkey) & !viewDirectionRight)
        {
            Debug.Log("PewPew");
            GameObject clone = Instantiate(projectile, spawnPosition.transform.position, Quaternion.identity);
            Rigidbody rigid = clone.GetComponent<Rigidbody>();
            rigid.AddForce(-shootSpeed);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Restart Key");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


    }

}