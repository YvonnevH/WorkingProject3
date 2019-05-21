using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    void Start()
    {
		dialogOn = false;
		lastSentenceDisplayed = false;
		magicGiven = false;
        sentences = new Queue<string>();
    }
	
	void Update()
	{
		if(magicGiven == false && talkingToCorrectNPC == true && sentences.Count == 0 && lastSentenceDisplayed==false){
					//Trigger correct GiveMagic
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
		dialogOn = true;
		foreach (string sentence in dialogue.sentences){
			sentences.Enqueue(sentence);
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
	}
	
	void LastSentence(){
		if (GetComponent<TalkingOrderController>().talkTo == 0){
			lastSentence = "Praat maar eens met de Tovenaar";
		}
		else if (GetComponent<TalkingOrderController>().talkTo == 1){
			lastSentence = "Praat maar eens met de Bakker";
		}
		else if (GetComponent<TalkingOrderController>().talkTo == 2){
			lastSentence = "Praat maar eens met de Visser";
		}
		else if (GetComponent<TalkingOrderController>().talkTo == 3){
			lastSentence = "Praat maar eens met de Kluizenaar";
		}
		else if (GetComponent<TalkingOrderController>().talkTo == 4){
			lastSentence = "Praat maar eens met de Jager";
		}
		dialogueText.text = lastSentence;
		lastSentenceDisplayed = true;
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
