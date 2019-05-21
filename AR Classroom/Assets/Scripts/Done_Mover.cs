using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;
    public float lifeTime = 5f;

    void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }


    void Update()
    {
        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
