using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPull : MonoBehaviour
{

    public GameObject prefab = null;
    public GameObject[] pooling = null;
    public int maxObjects = 0;

    private static ObjectPull uniqueInstance =  null;
    public static ObjectPull GetInstance()
    {
        
        return uniqueInstance;

    }

    public void Create(Vector3 position, Quaternion rotation, Vector3 scale)
    {
        for (int i = 0; i < maxObjects; i++)
        {
            if (!pooling[i].activeSelf)
            {
                pooling[i].transform.position = position;
                pooling[i].transform.rotation = rotation;
                pooling[i].transform.localScale = scale;

                pooling[i].SetActive(true);
                break;
            }
        }

        //var cloneBullet = Instantiate(bullet, spawnBullet.position, Quaternion.identity);
        //cloneBullet.transform.localScale = this.transform.localScale;
    }

    public void ReturnToPoll(GameObject PoolObject)
    {
        PoolObject.SetActive(false);
    }

    private void Awake()
    {
        if (uniqueInstance == null)
        {
            uniqueInstance = this;
            //Debug.Log("CRIOU INSTANCIA");
        }
        else
        {
            Destroy(this.gameObject);
        }

        pooling = new GameObject[maxObjects];

        for (int i=0; i< maxObjects; i++)
        {
            pooling[i] = GameObject.Instantiate<GameObject>(prefab);
            pooling[i].SetActive(false);
        }
    }

}
