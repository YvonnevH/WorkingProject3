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
        Debug.Log("List contains this object" + ARController.GetComponent<ARController>().currentTrackedObjects.Contains(gameObject.name.ToString()));
        Debug.Log("List contains right NPC" + ARController.GetComponent<ARController>().currentTrackedObjects.Contains(RightNPC.name.ToString()));
        if (ARController.GetComponent<ARController>().currentTrackedObjects.Contains(gameObject.name.ToString())
		&& ARController.GetComponent<ARController>().currentTrackedObjects.Contains(RightNPC.name.ToString()))
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
