using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Story : MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }
   public void click()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(sceneName);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
