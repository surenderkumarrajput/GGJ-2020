using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tuorialcanvas : MonoBehaviour
{
    public GameObject info;
    public GameObject tab;
    // Start is called before the first frame update
    void Start()
    {
        info.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            tab.SetActive(false);
            bool active = info.activeSelf;
            info.SetActive(!active);
        }
    }
}
