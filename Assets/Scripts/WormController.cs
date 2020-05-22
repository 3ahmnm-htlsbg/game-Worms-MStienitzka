using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormController : MonoBehaviour
{
    // Start is called before the first frame update
    public KeyCode jumpKey;
    public KeyCode fowardKey;
    public Rigidbody z;

    public Vector3 x;
    public Vector3 y;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(jumpKey))
        {
            Debug.Log("Jump wurde gedrückt");
            z.AddForce(x);
        }

        if (Input.GetKeyDown(fowardKey))
        {
            Debug.Log("Fowaerts wurde gedrückt");
            z.AddForce(y);
        }

    }
}
