using System.Collections;
using UnityEngine;

public class AllPoker : MonoBehaviour {
    public AllPoker()
    {
    }

    // Use this for initialization
    void Start () {
        //获取所有扑克 按随机数分成3分 其他游戏者更换贴图 去除button 各自分发出去
        GameObject []gameObject = GameObject.FindGameObjectsWithTag("poker");
        ArrayList allPoker = new ArrayList();
        for(int f = 0; f < gameObject.Length; f ++)
        {
            allPoker.Add(gameObject[f]);
        }

        ArrayList Poker1 = new ArrayList();
        ArrayList Poker2 = new ArrayList();
        ArrayList Poker3 = new ArrayList();
        Sprite backSprite = Resources.Load<Sprite>("img/back");
        for (int f = 0; f < 4; f ++ )
        {
            Poker1.Add(allPoker[Random.Range(0, allPoker.Count)]);
            allPoker.Remove(Poker1[f]);
            Poker2.Add(allPoker[Random.Range(0, allPoker.Count)]);
            allPoker.Remove(Poker2[f]);
            (Poker2[f] as GameObject).GetComponent<Poker>().SetImage(backSprite);
            (Poker2[f] as GameObject).GetComponent<Poker>().DisabledBtn();
            Poker3.Add(allPoker[Random.Range(0, allPoker.Count)]);
            allPoker.Remove(Poker3[f]);
            (Poker3[f] as GameObject).GetComponent<Poker>().SetImage(backSprite);
            (Poker3[f] as GameObject).GetComponent<Poker>().DisabledBtn();
        }
        GameObject.Find("Player1").GetComponent<PokerManage>().addPokers(Poker1, null);
        GameObject.Find("Player2").GetComponent<PokerManage>().addPokers(Poker2, null);
        GameObject.Find("Player3").GetComponent<PokerManage>().addPokers(Poker3, null);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
