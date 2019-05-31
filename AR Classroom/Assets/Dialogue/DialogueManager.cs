using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
	public Text nameText;
	public Text dialogueText;
	public bool dialogOn;
	public GameObject dialogueBox;
	string lastSentence;
	public bool lastSentenceDisplayed;
    public bool magicGiven;
	public bool talkingToCorrectNPC;
	public int NPCnumber;
	public GameObject[] Player;
	
    private Queue<string> sentences;
    private Queue<AudioClip> voiceovers;
    private AudioSource currentAudio;

    public bool waitUntilMagicGiven = false;

    void Start()
    {
		dialogOn = false;
		lastSentenceDisplayed = false;
		magicGiven = false;
        sentences = new Queue<string>();
        voiceovers = new Queue<AudioClip>();
        currentAudio = GetComponent<AudioSource>();
    }
	
	void Update()
	{
		if(magicGiven == false && talkingToCorrectNPC == true && sentences.Count == 0 && lastSentenceDisplayed==false){
            //Trigger correct GiveMagic
            Debug.Log("Trigger GiveMagic");
			Player[NPCnumber].GetComponent<GiveMagic>().GiveMagicTrigger();
            waitUntilMagicGiven = true;
		}
		if (Input.GetMouseButtonDown(0) && waitUntilMagicGiven == false){
			if (sentences.Count == 0 && lastSentenceDisplayed==true){
				EndDialogue();
				return;
			}
            if (dialogOn == true)
            {
                if (!currentAudio.isPlaying)
                {
                    DisplayNextSentence();
                }
            }
        }
		dialogueBox.SetActive(dialogOn);
	}
	
	public void StartDialogue(Dialogue dialogue){
		nameText.text = dialogue.name;
		sentences.Clear();
        voiceovers.Clear();
		dialogOn = true;
		foreach (string sentence in dialogue.sentences){
			sentences.Enqueue(sentence);
		}
        foreach (AudioClip voiceover in dialogue.voiceovers) //TOEGEVOEGD
        {
            voiceovers.Enqueue(voiceover);
        }
        DisplayNextSentence();
	}
	public void DisplayNextSentence (){
		if(sentences.Count == 0 && lastSentenceDisplayed==false){
				LastSentence();
				return;
		}
		string sentence = sentences.Dequeue();
		dialogueText.text = sentence;
        AudioClip voiceover = voiceovers.Dequeue(); // TOEGEVOEGD
        currentAudio.clip = voiceover;
        currentAudio.Play();

        
    }
	
	void LastSentence(){
        if (GetComponent<TalkingOrderController>().talkingCounter == 4)
        {
            Debug.Log("NextScene");
            SceneManager.LoadScene("MidSceneNew", LoadSceneMode.Single); //moet load next scene worden
            return;
        }
        if (magicGiven == true && talkingToCorrectNPC == true)
        {
            if (GetComponent<TalkingOrderController>().talkTo == 0)
            {
                lastSentence = "Praat maar eens met de Tovenaar";
            }
            else if (GetComponent<TalkingOrderController>().talkTo == 1)
            {
                lastSentence = "Praat maar eens met de Bakker";
            }
            else if (GetComponent<TalkingOrderController>().talkTo == 2)
            {
                lastSentence = "Praat maar eens met de Visser";
            }
            else if (GetComponent<TalkingOrderController>().talkTo == 3)
            {
                lastSentence = "Praat maar eens met de Kluizenaar";
            }else if (GetComponent<TalkingOrderController>().talkTo == 4)
            {
                GetComponent<TalkingOrderController>().CounterUp();
            }
            dialogueText.text = lastSentence;
            lastSentenceDisplayed = true;
            magicGiven = false;
            return;
        }
        else if (talkingToCorrectNPC == false)
        {
            if (GetComponent<TalkingOrderController>().talkTo == 0)
            {
                lastSentence = "Praat maar eens met de Tovenaar";
            }
            else if (GetComponent<TalkingOrderController>().talkTo == 1)
            {
                lastSentence = "Praat maar eens met de Bakker";
            }
            else if (GetComponent<TalkingOrderController>().talkTo == 2)
            {
                lastSentence = "Praat maar eens met de Visser";
            }
            else if (GetComponent<TalkingOrderController>().talkTo == 3)
            {
                lastSentence = "Praat maar eens met de Kluizenaar";
            }
            dialogueText.text = lastSentence;
            lastSentenceDisplayed = true;
        }
	}
	
	void EndDialogue(){
		Debug.Log("End of conversation.");
		if (dialogOn == true){
		    dialogOn = false;
		}
		lastSentenceDisplayed = false;
		magicGiven = false;
        talkingToCorrectNPC = false;
    }
}
