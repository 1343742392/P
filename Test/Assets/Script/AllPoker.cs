using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AllPoker : MonoBehaviour {
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject chapter = null;
    public float theyPokerScale = 0.6f;
    int addBackNum = 0;
    GameObject player1;
    GameObject player2;
    GameObject player3;
    public ArrayList allPoker;
    public int bottonMoney = 10;


    bool isEnd = false;
    public AllPoker()
    {
    }

    // Use this for initialization
    void Start () {
        //获取所有扑克 按随机数分成3分 其他游戏者更换贴图 去除button 各自分发出去
        GameObject []gameObject = GameObject.FindGameObjectsWithTag("poker");
        allPoker = new ArrayList();
        for(int f = 0; f < gameObject.Length; f ++)
        {
            allPoker.Add(gameObject[f]);
        }

        ArrayList Poker1 = new ArrayList();
        ArrayList Poker2 = new ArrayList();
        ArrayList Poker3 = new ArrayList();
        Sprite backSprite = Resources.Load<Sprite>("img/back");
        for (int f = 0; f < 5; f ++ )
        {
            Poker1.Add(allPoker[Random.Range(0, allPoker.Count)]);
            allPoker.Remove(Poker1[f]);
            Poker2.Add(allPoker[Random.Range(0, allPoker.Count)]);
            allPoker.Remove(Poker2[f]);
            (Poker2[f] as GameObject).GetComponent<Poker>().Turn();
            (Poker2[f] as GameObject).GetComponent<Poker>().ClickAble(false);
            (Poker2[f] as GameObject).GetComponent<RectTransform>().localScale = new Vector3(theyPokerScale, theyPokerScale);
            Poker3.Add(allPoker[Random.Range(0, allPoker.Count)]);
            allPoker.Remove(Poker3[f]);
            (Poker3[f] as GameObject).GetComponent<Poker>().Turn();
            (Poker3[f] as GameObject).GetComponent<Poker>().ClickAble(false) ;
            (Poker3[f] as GameObject).GetComponent<RectTransform>().localScale = new Vector3(theyPokerScale, theyPokerScale);
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
        if (isEnd) return;
        switch(player.name)
        {
            case "Player1":
                player1.GetComponent<PokerManage>().outPokerAble = false;
                player2.GetComponent<PokerManage>().outPokerAble = true;
                player2.GetComponent<AI>().OutPoker();
                break;
            case "Player2":
                player2.GetComponent<PokerManage>().outPokerAble = false;
                player3.GetComponent<PokerManage>().outPokerAble = true;
                player3.GetComponent<AI>().OutPoker();
                break;
            case "Player3":
                player3.GetComponent<PokerManage>().outPokerAble = false;
                player1.GetComponent<PokerManage>().outPokerAble = true;
                string[] buts = null;
                if(player1.GetComponent<PokerManage>().HaveUpPoker())
                {
                    buts = new string[] { ButtonManage.ButtonNames.OutPoker, ButtonManage.ButtonNames.Next };
                }
                else
                {
                    buts = new string[] {ButtonManage.ButtonNames.Next };
                }
                buttons.GetComponent<ButtonManage>().SetButtons(buts, delegate(string result)
                {
                    buttons.GetComponent<ButtonManage>().SetButtons(new string[] { });
                    player1.GetComponent<PokerManage>().mIsNext = true;
                    Sprite s = Resources.Load<Sprite>("img/next");
                    ShowWord.Say(new Vector3(0, -50, 0), s, delegate () { outPokerEnd(player1); });
                });
                TimeManage.SetTimer(30, delegate () 
                { 
                    player1.GetComponent<PokerManage>().mIsNext = true;
                    Sprite s = Resources.Load<Sprite>("img/next");
                    ShowWord.Say(new Vector3(0, -50, 0), s, delegate() { outPokerEnd(player1); });
                });
                break;
        }
    }


    void addPokerBack()
    {
        addBackNum++;
        if(addBackNum == 3)
        {
            string[] s = new string[2];
            s[0] = ButtonManage.ButtonNames.BeLandlord;
            s[1] = ButtonManage.ButtonNames.DoNot;
            buttons.GetComponent<ButtonManage>().SetButtons(s, ButtonBack);
            TimeManage.SetTimer(4, landlordTimeout);
            addBackNum = 0;
        }

    }


    void ButtonBack(string name)
    {
        switch(name)
        {
            case ButtonManage.ButtonNames.BeLandlord:
                Judge.AddOdds(2);
                buttons.GetComponent<ButtonManage>().SetButtons(new string[] {});
                TimeManage.SetTimer(30, outPokerTimeout);
                player1.GetComponent<PokerManage>().outPokerAble = true;
                chapter.transform.parent.transform.position = gameObject.transform.position + new Vector3(0, 200, 0);
                chapter.GetComponent<Animator>().Play("toPlayer1");
                ArrayList ps = new ArrayList();
                ps.Add(allPoker[Random.Range(0, allPoker.Count)]);
                allPoker.Remove(ps[0]);
                ps.Add(allPoker[Random.Range(0, allPoker.Count)]);
                allPoker.Remove(ps[1]);
                ps.Add(allPoker[0]);
                allPoker.RemoveAt(0);
                player1.GetComponent<PokerManage>().addPokers(ps);
                break;
            case ButtonManage.ButtonNames.DoNot:
                
                SceneManager.LoadScene("1");
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

    public void End(GameObject g)
    {
        isEnd = true;
        
        player1.GetComponent<PokerManage>().outPokerAble = false;
        player2.GetComponent<PokerManage>().outPokerAble = false;
        player3.GetComponent<PokerManage>().outPokerAble = false;

        buttons.GetComponent<ButtonManage>().SetButtons(new string[] { });

        GameObject canvas = GameObject.FindWithTag("canvas");
        Vector2 center = new Vector2(canvas.GetComponent<RectTransform>().rect.width / 2, canvas.GetComponent<RectTransform>().rect.height / 2 + 50f);
        if (g.name == "Player1")
        {
            GameObject.Find("GameResult").transform.position = center;

            GameObject oddg = GameObject.Find("odds");
            GameObject money = GameObject.Find("money");
            money.GetComponent<Text>().text = "+  " + bottonMoney * Judge.GetOdds() + "";
            oddg.GetComponent<Text>().text = Judge.GetOdds() + "";
        }
        else
        {
            GameObject gr = GameObject.Find("GameResult");
            gr.GetComponent<Image>().sprite = Resources.Load<Sprite>("img/fail");
            gr.transform.position = center;

            GameObject oddg = GameObject.Find("odds");
            GameObject money = GameObject.Find("money");
            money.GetComponent<Text>().text = "-  " + bottonMoney * Judge.GetOdds() + "";
            oddg.GetComponent<Text>().text = Judge.GetOdds() + "";
        }
    }

    public void RePlaye()
    {
        SceneManager.LoadScene("1");
    }

    public void SignOut()
    {
        SceneManager.LoadScene("Start");
    }
}
