using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerSort : IComparer
{

    int IComparer.Compare(object x, object y)
    {
        PokerAttr a = (x as GameObject).GetComponent<PokerAttr>();
        PokerAttr b = (y as GameObject).GetComponent<PokerAttr>();
        if (a.size > b.size)

        {
            return 1;
        }
        else if (a.size < b.size)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
}
