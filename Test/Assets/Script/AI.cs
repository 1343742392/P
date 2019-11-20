using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    // Start is called before the first frame update
    public bool doLandlord = false;
    GameObject allPoker = null;
    public Vector3 wordPos = new Vector3();
    public int useTime = 2;

    void Start()
    {
        allPoker = GameObject.Find("AllPoker");
        //                         地主或者player1 或2  手上的牌0表示没有  上家出的牌  已经出了的牌
        /*
        float [] numOutputClasses = { };
        Parameter bias = new Parameter(new int[] { numOutputClasses }, DataType.Float, 0);
        Parameter weights = new Parameter(new int[] { input.Shape[0], numOutputClasses }, DataType.Float,
          CNTKLib.GlorotUniformInitializer(
            CNTKLib.DefaultParamInitScale,
            CNTKLib.SentinelValueForInferParamInitRank,
            CNTKLib.SentinelValueForInferParamInitRank, 1));
        var z = CNTKLib.Plus(bias, CNTKLib.Times(weights, input));
        Function logisticClassifier = CNTKLib.Sigmoid(z, "LogisticClassifier");*/
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OutPoker()
    {
        PokerManage pokerManage = GetComponent<PokerManage>();

        TimeManage.SetTimer(30, delegate ()
        {
            pokerManage.mIsNext = true;
            Sprite s = Resources.Load<Sprite>("img/next");
            ShowWord.Say(wordPos, s, SayEnd);
        });
        pokerManage.mIsNext = false;
        ArrayList pks = GreaterPoker();
        AllPoker aps = allPoker.GetComponent<AllPoker>();
        if(pks.Count != 0)
        {
            Debug.Log(gameObject.name + "out poker:" + (pks[0] as GameObject).GetComponent<PokerAttr>().size);
            CallBack.Set(useTime, delegate () {
                Judge.beforePoker = new Comb(pks);
                pokerManage.OutPoker(pks);
                pokerManage.RefreshPoker();
                aps.outPokerEnd(gameObject);
            });
        }
        else
        {
            pokerManage.mIsNext = true;
            Sprite s = Resources.Load<Sprite>("img/next");
            ShowWord.Say(wordPos, s, SayEnd);
          
        }

       
    }

    void SayEnd()
    {
        allPoker.GetComponent<AllPoker>().outPokerEnd(gameObject);
    }

    ArrayList GreaterPoker()
    {
        ArrayList result = new ArrayList();
        int beforeLenght = Judge.beforePoker.length;
        ArrayList havePokers =  GetComponent<PokerManage>().pokers;
        if(!Judge.HaveOutPoker())
        {
            result.Add(havePokers[0]);
            return result;
        }
        List<int> hpl = new List<int>();
        for(int f = 0; f < havePokers.Count; f ++)
        {
            hpl.Add((havePokers[f] as GameObject).GetComponent<PokerAttr>().size);
        }

        if (beforeLenght == 0)
        {
            result.Add(havePokers[0]);
            return result;
        }

        for(int f = 0; f < havePokers.Count - beforeLenght; f ++)
        {
            Comb c = new Comb(hpl.GetRange(f, beforeLenght));
            if(c.type != Comb.PokerType.Without && Judge.Legitimate(c))
            {
                return havePokers.GetRange(f, beforeLenght);
            }
        }
        return result;
    }
}
