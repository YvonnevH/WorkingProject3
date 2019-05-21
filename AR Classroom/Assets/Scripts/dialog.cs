using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class dialog : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    bool nextText = false;


    private void Start()
    {
        StartCoroutine(type());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (nextText == true)
            {
                NextSentence();
            }
        }

        if (textDisplay.text == sentences[index]){
            nextText = true;
        }
    }

    IEnumerator type()
    {
        foreach(char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);

        }
    }

    public void NextSentence()
    {
        nextText = false;

        if(index < sentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(type());
        }
        else
        {
            textDisplay.text = "";
            nextText = false;
            StartCoroutine(theEnd());
        }
    }

    IEnumerator theEnd()
    {
        Scene scene = SceneManager.GetActiveScene();
        switch (scene.name)
        {
            case "StartScene":
                SceneManager.LoadScene("FirstGame", LoadSceneMode.Single);
                break;
            case "MidSceneNew":
                SceneManager.LoadScene("DragonGame", LoadSceneMode.Single);
                break;
            case "EndSceneNew":
                yield return new WaitForSeconds(2);
                Application.Quit();
                break;
        }
    }

}
