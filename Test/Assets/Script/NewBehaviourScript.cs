using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] int one = 0;
    [SerializeField] int two = 0;
    [SerializeField] int three = 0;
    [SerializeField] int four = 0;
    [SerializeField] int five = 0;
    [SerializeField] int six = 0;
    [SerializeField] int length = 6;
    void Start()
    {
        /*        List<int> ls = new List<int>();
                ls.Add(one);
                ls.Add(two);
                ls.Add(three);
                ls.Add(four);
                ls.Add(five);
                ls.Add(six);
                Debug.Log(new Comb(ls.GetRange(0, length)).ToString());*/
        Sprite s = Resources.Load<Sprite>("img\\allPoker2");
        Debug.Log(s == null);
    }

    // Update is called once per frame
    void Update()
    {
/*        List<int> ls = new List<int>();
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        Debug.Log(new Comb(ls.GetRange(0, Random.Range(1, 8))).ToString());
        Debug.Log(ls.ToString());*/
    }
}
