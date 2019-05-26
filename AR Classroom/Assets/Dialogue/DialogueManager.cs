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
    void Start()
    {
		dialogOn = false;
		lastSentenceDisplayed = false;
		magicGiven = false;
        sentences = new Queue<string>();
        voiceovers = new Queue<AudioClip>();
    }
	
	void Update()
	{
		if(magicGiven == false && talkingToCorrectNPC == true && sentences.Count == 0 && lastSentenceDisplayed==false){
            //Trigger correct GiveMagic
            Debug.Log("Trigger GiveMagic");
					Player[NPCnumber].GetComponent<GiveMagic>().GiveMagicTrigger();
				}
		if (Input.GetMouseButtonDown(0)){
			if (sentences.Count == 0 && lastSentenceDisplayed==true){
				EndDialogue();
				return;
			}
			DisplayNextSentence();
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
        AudioSource.PlayClipAtPoint(voiceover, new Vector3(5, 1, 2));

    }
	
	void LastSentence(){
        if (GetComponent<TalkingOrderController>().talkingCounter == 5)
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
            }
            else if (GetComponent<TalkingOrderController>().talkTo == 4)
            {
                lastSentence = "Praat maar eens met de Jager";
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
            else if (GetComponent<TalkingOrderController>().talkTo == 4)
            {
                lastSentence = "Praat maar eens met de Jager";
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
	}
}
