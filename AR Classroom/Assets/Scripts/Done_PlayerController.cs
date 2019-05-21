using UnityEngine;
using System.Collections;

[System.Serializable]
public class Done_Boundary 
{
	public float xMin, xMax, zMin, zMax;
}

public class Done_PlayerController : MonoBehaviour
{
	public float speed;

	public GameObject shot;
	public Transform shotSpawn;
    public float fireRate;
	private float nextFire;

    public GameObject targetObject;
    private Done_GameController gameController;
    Animator anim;
    private float delayTime = 0.6f;
    public float setTime = 0.6f;
    private bool timer = false;
   
    private void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        gameController = gameControllerObject.GetComponent<Done_GameController>();
        anim = this.gameObject.GetComponent<Animator>();
        delayTime = setTime;
    }

    private void Update()
	{
        if ( Time.time > nextFire && targetObject.GetComponent<DefaultTrackableEventHandler>().targetTracked == true && gameController.gameOver == false)  //Input.GetButton("Fire1") &&
		{
			nextFire = Time.time + fireRate;
            if (anim != null)
            {
                anim.Play("Attack");
            }
            timer = true;
            GetComponent<AudioSource>().Play ();
		}
        if (timer == true)
        {
            delayTime -= Time.deltaTime;
        }
        if (delayTime <= 0)
        {
            GameObject fire = Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            delayTime = setTime;
            timer = false;
        }
	}
}
