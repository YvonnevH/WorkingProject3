using UnityEngine;
using System.Collections;

public class Done_DestroyByContact : MonoBehaviour
{
	public GameObject bulletExplosion;
	private Done_GameController gameController;
    Animator anim;
    private Collider collidingBullet;

    void Start ()
	{
		GameObject gameControllerObject = GameObject.FindGameObjectWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <Done_GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
        anim = this.gameObject.GetComponent<Animator>();
    }
    
    void OnTriggerEnter (Collider other)
	{
        collidingBullet = other;
        Debug.Log("Collision: " + other.gameObject.name);
        if (other.tag == "Boundary" || other.tag == "Enemy")
		{
			return;
		}

		if (other.tag == "Bullet")
		{
            gameController.dragonHit(other.gameObject.name);           
            
        }	
	}

    public void dragonHit()
    {
        //
        if (bulletExplosion != null)
        {
            Instantiate(bulletExplosion, collidingBullet.transform.position, collidingBullet.transform.rotation);
        }
        Destroy(collidingBullet.gameObject);
        //
        anim.Play("Hit");
    }

    public void dragonDie()
    {
        anim.Play("GameOver");
    }

    public void HeroDie()           //After GameOver animation
    {
        gameController.activateStar();
        Destroy(this.gameObject);
    }
}