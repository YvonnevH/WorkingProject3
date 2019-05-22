using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiveMagic : MonoBehaviour
{
	public GameObject ARController;
	public GameObject DialogueManager;
	public GameObject RightNPC;
    public bool magicGiven;
		
	void Start()
    {
        magicGiven = false;
		ARController = GameObject.Find("ARController");
		DialogueManager = GameObject.Find("DialogueManager");
    }
	
	public void GiveMagicTrigger(){
        Debug.Log("List contains this object" + Contains(ARController.GetComponent<ARController>().currentTrackedObjects, gameObject.ToString()));
        Debug.Log("List contains right NPC" + Contains(ARController.GetComponent<ARController>().currentTrackedObjects, RightNPC.ToString()));
        if (ARController.GetComponent<ARController>().currentTrackedObjects.Contains(gameObject.ToString())
		&& ARController.GetComponent<ARController>().currentTrackedObjects.Contains(RightNPC.ToString()))
			{
			gameObject.transform.GetChild(1).gameObject.SetActive(true);
            magicGiven = true;
			DialogueManager.GetComponent<DialogueManager>().magicGiven = magicGiven;
            Debug.Log("GiveMagic triggered");
		}
	}
    bool Contains(List<string> list, string String)
    {
        foreach (string s in list)
        {
            if (s == String)
                {return true;}
        }

        return false; 
    }
}
