using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {


    public Vector2 speed = new Vector2(2,0);
    public Rigidbody2D rbBullet;
    public float destroyTime = 1.0f;

    private float deltaTime = 0.00f;


	// Use this for initialization
	void Start () {

        //Destroy(gameObject, destroyTime);

        rbBullet = GetComponent<Rigidbody2D>();
	}

    private void OnEnable()
    {
        rbBullet.velocity = speed * this.transform.localScale.x;
    }

    // Update is called once per frame
    void Update () {
        deltaTime += Time.deltaTime;
		if (deltaTime >= destroyTime)
        {
            ObjectPull.GetInstance().ReturnToPoll(this.gameObject);
            deltaTime = 0.00f;
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!collision.gameObject.CompareTag("Player"))
        {
            deltaTime = destroyTime;
        }
        else if (collision.gameObject.CompareTag("Enemyes"))
        {
            Destroy(this);
        }
    }





}
