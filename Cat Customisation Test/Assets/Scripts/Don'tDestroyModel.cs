 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyModel : MonoBehaviour
{
    private static DontDestroyModel instance;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
