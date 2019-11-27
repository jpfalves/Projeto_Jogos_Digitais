using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Plant : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D colisor)
    {
        if (colisor.gameObject.tag == "Tiro")
        {
            Destroy(gameObject);
        }
    }
}
