using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{
    [SerializeField] static int Odds = 4;
    static  public Comb beforePoker = new Comb();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static public int GetOdds()
    {
        return Odds;
    }

    static public void AddOdds(int value)
    {
        Odds *= value;
        GameObject.Find("OddValue").GetComponent<Text>().text = Odds + "";
    }

    public static bool HaveOutPoker()
    {
        GameObject[] player = new GameObject[] {GameObject.FindWithTag("player1"),
        GameObject.FindWithTag("player2"),
        GameObject.FindWithTag("player3")};
        int index = 0;
        foreach (GameObject g in player)
        {
            if (g.GetComponent<PokerManage>().mIsNext) index++;
        }
        //Debug.Log("index:" + index);
        if(index >=2 )
        {
            return false;
        }
        return true;
    }

    static public bool Legitimate(Comb comb)
    {

        //是否有组合
        if (comb.type == Comb.PokerType.Without)
        {
            return false;
        }

        
        if (beforePoker.type == Comb.PokerType.Empty || !HaveOutPoker())
        {
            return true;
        }
        //和前面的牌比
        if (comb.type == Comb.PokerType.Bomb)
        {
            if(beforePoker.type != Comb.PokerType.Bomb )
            {
                return false;
            }
            if(beforePoker.size > comb.size)
            {
                return false;
            }
            return true;
        }

        if(beforePoker.length == comb.length && comb.size > beforePoker.size && comb.type == beforePoker.type)
        {
            return true;
        }
        
        return false;
    }
}
