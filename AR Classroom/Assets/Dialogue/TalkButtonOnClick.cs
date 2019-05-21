using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkButtonOnClick : MonoBehaviour
{
public GameObject dialogObject;
public GameObject dialogObjectWrongTime;
public bool wrongTime;
public int NPCnumber; // 0-tovenaar, 1-bakker, 2-visser, 3-kluizenaar
public GameObject DialogueManager;

	
	void OnMouseDown(){
		DialogueManager.GetComponent<DialogueManager>().NPCnumber = NPCnumber;
		// update wrongTime boolean
		if(DialogueManager.GetComponent<TalkingOrderController>().talkTo == NPCnumber){
			wrongTime = false;
			DialogueManager.GetComponent<DialogueManager>().talkingToCorrectNPC = true;
		}
		else{
			wrongTime = true;
			DialogueManager.GetComponent<DialogueManager>().talkingToCorrectNPC = false;
		}
		
		// determine which dialog to trigger
		if (wrongTime == true){
			dialogObjectWrongTime.GetComponent<DialogueTrigger>().TriggerDialogue();
		}
		else{
			dialogObject.GetComponent<DialogueTrigger>().TriggerDialogue();
			DialogueManager.GetComponent<TalkingOrderController>().CounterUp();
		}
		gameObject.SetActive(false);
	}
	
}
