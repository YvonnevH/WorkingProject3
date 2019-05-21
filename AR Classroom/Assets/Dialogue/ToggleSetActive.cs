using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSetActive : MonoBehaviour
{
	void Update(){
		if (FindObjectOfType<DialogueManager>().dialogOn == false){
			gameObject.transform.GetChild(0).gameObject.SetActive(true);
		}
	}
}
