using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    [SerializeField] int Odds = 4;
    static Comb beforePoker = new Comb();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddOdds(int value)
    {
        Odds *= value;
    }

    static public bool Legitimate(Comb comb)
    {
        if (beforePoker.type == Comb.PokerType.Empty)
        {
            return true;
        }
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

        if(beforePoker.length == comb.size && comb.size > beforePoker.size && comb.type == beforePoker.type)
        {
            return true;
        }
        
        return false;
    }
}
