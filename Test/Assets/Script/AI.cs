using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    public bool doLandlord = false;
    GameObject allPoker = null;

    void Start()
    {
        allPoker = GameObject.Find("AllPoker");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OutPoker()
    {
        List<int> result = new List<int>();
        WordManage w = GetComponent<WordManage>();
        gameObject.GetComponent<PokerManage>().mIsNext = true;
        w.SayNext( SayEnd);
         
        
    }

    void SayEnd()
    {
        allPoker.GetComponent<AllPoker>().outPokerEnd(gameObject);
    }
}
