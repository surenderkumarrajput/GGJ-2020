using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Startfunction()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene("Intro");
    }
}
