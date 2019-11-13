using System.Collections;
using UnityEngine;

public class AllPoker : MonoBehaviour {
    [SerializeField] GameObject buttons;
    int addBackNum = 0;
    GameObject player1;
    GameObject player2;
    GameObject player3;
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
        for (int f = 0; f < 13; f ++ )
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
        player1 = GameObject.FindGameObjectWithTag("player1");
        player2 = GameObject.FindGameObjectWithTag("player2");
        player3 = GameObject.FindGameObjectWithTag("player3");
        player1.GetComponent<PokerManage>().addPokers(Poker1, addPokerBack);
        player2.GetComponent<PokerManage>().addPokers(Poker2, addPokerBack);
        player3.GetComponent<PokerManage>().addPokers(Poker3, addPokerBack);
    }

    public void outPokerEnd(GameObject player)
    {
        switch(player.name)
        {
            case "Player1":
                player1.GetComponent<PokerManage>().outPokerAble = false;
                player2.GetComponent<PokerManage>().outPokerAble = true;
                break;
            case "Player2":
                player2.GetComponent<PokerManage>().outPokerAble = false;
                player3.GetComponent<PokerManage>().outPokerAble = true;
                break;
            case "Player3":
                player3.GetComponent<PokerManage>().outPokerAble = false;
                player1.GetComponent<PokerManage>().outPokerAble = true;
                break;
        }
    }


    void addPokerBack()
    {
        addBackNum++;
        if(addBackNum == 3)
        {
            string[] s = new string[2];
            s[0] = "beLandlord";
            s[1] = "doNot";
            buttons.GetComponent<ButtonManage>().SetButtons(s, ButtonBack);
            GameObject.Find("time").GetComponent<TimeManage>().SetTimer(4, landlordTimeout);
            addBackNum = 0;
        }

    }


    void ButtonBack(string name)
    {
        switch(name)
        {
            case "beLandlord":
                buttons.GetComponent<ButtonManage>().SetButtons(new string[] { });
                GameObject.Find("time").GetComponent<TimeManage>().SetTimer(30, outPokerTimeout);
                player1.GetComponent<PokerManage>().outPokerAble = true;
                break;
            default:
                break;
        }
        buttons.GetComponent<ButtonManage>().SetButtons(new string[] { });

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void landlordTimeout()
    {

    }

    void outPokerTimeout()
    {

    }
}
