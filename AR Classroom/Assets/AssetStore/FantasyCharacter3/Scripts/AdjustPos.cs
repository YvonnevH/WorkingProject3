using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class AdjustPos : ScriptableObject
{
    [MenuItem("Tool/adjustPos")]
    static void doti()
    {
        GameObject obj = GameObject.Find("bigzhangjiao (1)");
        GameObject[] objs = Selection.gameObjects;
        for(int i = 0; i < objs.Length; i++)
        {
            Vector3 pos = objs[i].transform.position;
            pos.y = obj.transform.position.y;
            objs[i].transform.position = pos;
            objs[i].transform.LookAt(obj.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
