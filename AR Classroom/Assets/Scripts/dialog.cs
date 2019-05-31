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
    public AudioClip[] voiceoversArray;
    private Queue<AudioClip> voiceovers;

    private int index;
    public float typingSpeed;

    bool nextText = false;


    private void Start()
    {
        voiceovers = new Queue<AudioClip>();
        foreach (AudioClip voiceover in voiceoversArray) //TOEGEVOEGD
        {
            voiceovers.Enqueue(voiceover);
        }
        
        StartCoroutine(type());
        //play first clip

        AudioClip playingVoiceover = voiceovers.Dequeue(); // TOEGEVOEGD
        AudioSource.PlayClipAtPoint(playingVoiceover, new Vector3(5, 1, 2));
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
            //play clip

            AudioClip playingVoiceover = voiceovers.Dequeue(); // TOEGEVOEGD
            AudioSource.PlayClipAtPoint(playingVoiceover, new Vector3(5, 1, 2));
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
