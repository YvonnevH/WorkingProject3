using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingOrderController : MonoBehaviour
{
// Tovenaar = 0, Bakker = 1, Visser = 2, Kluizenaar = 3

public int [] order = new int[]{0,1,2,3};
public int talkingCounter;
public int talkTo;

    void Start()
    {
        ShuffleArray(order);
		talkingCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
		talkTo = order[talkingCounter];
		if(talkingCounter == 5){
			Application.Quit(); //moet load next scene worden
		}
	}
	
 public void CounterUp(){
	 talkingCounter++;
 }

 public static void ShuffleArray<T>(T[] arr) {
   for (int i = arr.Length - 1; i > 0; i--) {
     int r = Random.Range(0, i);
     T tmp = arr[i];
     arr[i] = arr[r];
     arr[r] = tmp;
   }
 }
 
}