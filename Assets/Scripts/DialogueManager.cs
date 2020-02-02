using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public Dialogues dialogue;
    public TextMeshProUGUI text;
    public GameObject Continue;
    public int index=0;
    public string scenename;
    void Start()
    {
        StartCoroutine(dialoguedisplay());
    }
    IEnumerator dialoguedisplay()
    {
        foreach (char c in dialogue.sentences[index].ToCharArray())
        {
            text.text += c;
            yield return new WaitForSeconds(0.1f);
        }

    }
    void Update()
    {
        if(text.text==dialogue.sentences[index])
        {
            Continue.SetActive(true);
        }
    }
    public void Nextsentence()
    {
        Continue.SetActive(false);
        if(index<dialogue.sentences.Length-1)
        {
            index++;
            text.text = "";
            StartCoroutine(dialoguedisplay());
        }
        else
        {
            text.text = "";
            SceneManager.LoadScene(scenename);
        }
    }
}
