using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMagic : MonoBehaviour
{
	public GameObject ARController;
	public GameObject DialogueManager;
	public GameObject RightNPC;
		
	void Start()
    {
		ARController = GameObject.Find("ARController");
		DialogueManager = GameObject.Find("DialogueManager");
    }
	
	public void GiveMagicTrigger(){
		if (ARController.GetComponent<ARController>().currentTrackedObjects.Contains(gameObject.ToString())
		&& ARController.GetComponent<ARController>().currentTrackedObjects.Contains(RightNPC.ToString()))
			{
			gameObject.transform.GetChild(1).gameObject.SetActive(true);
			DialogueManager.GetComponent<DialogueManager>().magicGiven = true;
		}
	}
}
