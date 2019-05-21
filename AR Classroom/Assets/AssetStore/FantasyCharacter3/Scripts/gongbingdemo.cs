using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gongbingdemo : MonoBehaviour
{
    /*
    public GameObject attackBullet;
    public GameObject magicBullet;
    public GameObject magic2Bullet;
    public GameObject ultimateBullet;
    public GameObject damageEffect1;
    public GameObject damageEffect2;
    public GameObject damageEffect3;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ActionStart(string name)
    {

    }

    
   void preAction(string actionName)
   {

       AttackedController1 c = GameObject.Find("bigzhangjiao (1)").GetComponent<AttackedController1>();
       string[] arr = actionName.Split('|');
       string name = arr[0];
       switch (name)
       {
           case AnimationName1.Attack:
               if (attackBullet != null)
               {
                   GameObject obj = GameObject.Instantiate(attackBullet);
                   NormalBullet3 bullet = obj.GetComponent<NormalBullet3>();
                   bullet.player = transform;
                   bullet.target = GameObject.Find("bigzhangjiao (1)").transform;
                   bullet.effectObj = damageEffect1;
                   bullet.bulleting();
               }
               if (damageEffect1 != null)
               {
                   GameObject obj = GameObject.Instantiate(damageEffect1);
                   ParticlesEffect1 effect = obj.AddComponent<ParticlesEffect1>();
                   Transform target = GameObject.Find("bigzhangjiao (1)").transform;
                   effect.transform.position = MathUtil1.findChild(target, "attackedPivot").position;
                   effect.play();
               }
               c.attacked();
               break;
           case AnimationName1.Magic:
               if (attackBullet != null)
               {
                   GameObject obj = GameObject.Instantiate(attackBullet);
                   NormalBullet3 bullet = obj.GetComponent<NormalBullet3>();
                   bullet.player = transform;
                   bullet.target = GameObject.Find("bigzhangjiao (1)").transform;
                   bullet.effectObj = damageEffect1;
                   bullet.bulleting();
               }
               if (damageEffect1 != null)
               {
                   GameObject obj = GameObject.Instantiate(damageEffect1);
                   ParticlesEffect1 effect = obj.AddComponent<ParticlesEffect1>();
                   Transform target = GameObject.Find("bigzhangjiao (1)").transform;
                   effect.transform.position = MathUtil1.findChild(target, "attackedPivot").position;
                   effect.play();
               }
               c.attacked();

               break;
           case AnimationName1.Magic2:
               if (attackBullet != null)
               {
                   GameObject obj = GameObject.Instantiate(attackBullet);
                   NormalBullet3 bullet = obj.GetComponent<NormalBullet3>();
                   bullet.player = transform;
                   bullet.target = GameObject.Find("bigzhangjiao (1)").transform;
                   bullet.effectObj = damageEffect1;
                   bullet.bulleting();
               }
               if (damageEffect1 != null)
               {
                   GameObject obj = GameObject.Instantiate(damageEffect1);
                   ParticlesEffect1 effect = obj.AddComponent<ParticlesEffect1>();

                   effect.transform.position = GameObject.Find("bigzhangjiao (1)").transform.position;
                   effect.play();
               }
               c.attacked();
               break;
           case AnimationName1.Ultimate:
               if (attackBullet != null)
               {
                   GameObject obj = GameObject.Instantiate(attackBullet);
                   NormalBullet3 bullet = obj.GetComponent<NormalBullet3>();
                   bullet.player = transform;
                   bullet.target = GameObject.Find("bigzhangjiao (1)").transform;
                   bullet.effectObj = damageEffect1;
                   bullet.bulleting();
               }
               if (damageEffect2 != null)
               {
                   GameObject obj = GameObject.Instantiate(damageEffect2);
                   ParticlesEffect1 effect = obj.AddComponent<ParticlesEffect1>();

                   effect.transform.position = GameObject.Find("bigzhangjiao (1)").transform.position;
                   effect.play();
               }
               c.attacked();
               break;
       }
   }

   void ActionDone(string name)
   {

   }

   IEnumerator delayAttacked()
   {
       yield return new WaitForSeconds(1.5f);
       AttackedController1 c = GameObject.Find("bigzhangjiao (1)").GetComponent<AttackedController1>();
       c.attacked();
       //yield return new WaitForSeconds(2.5f);
       //c.attacked();
   }
   */
}
