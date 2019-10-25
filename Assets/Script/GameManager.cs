using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{

    private static GameManager uniqueInstance = null;

    public static GameManager GetInstance()
    {
        return uniqueInstance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Awake()
    {
        if (uniqueInstance == null)
        {
            uniqueInstance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
