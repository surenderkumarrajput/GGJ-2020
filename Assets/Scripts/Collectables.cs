using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public static Collectables instance;
    public GameObject path;
    void Start()
    {
        instance = this;  
    }

    void Update()
    {
        
    }
    public void PathDestroyonCollectables(GameObject Path)
    {
        Destroy(Path);
        Destroy(gameObject);
    }
}
