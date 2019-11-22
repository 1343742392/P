using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.EventTrigger;
using UnityEngine.Events;
using System;


    public class MenuTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {

    }


    [MenuItem("菜单/RemoveComponent")]
    public static void Test1()
    {
        GameObject []p = GameObject.FindGameObjectsWithTag("poker");
        for(int f = 0; f < p.Length; f ++)
        {
            GameObject g = p[f].transform.GetChild(0).gameObject;
            Component c = g.GetComponent<Button>();
            if (c != null)
            {
                DestroyImmediate(c);
            }
        }

    }

    [MenuItem("菜单/AddComponent")]
    public static void Test2()
    {
        GameObject[] p = GameObject.FindGameObjectsWithTag("poker");
        for (int f = 0; f < p.Length; f++)
        {
            GameObject g = p[f].transform.GetChild(0).gameObject;
            Debug.Log("run");
            g.AddComponent<EventTrigger>();
        }

    }

}

