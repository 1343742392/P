using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Comb 
{
    public enum PokerType { Empty,Without, Single, Double, Three, Bomb, MutipleFour, FourAndTwo}

    public PokerType type = PokerType.Without;

    public int length;

    public int size;
    public Comb() { type = PokerType.Empty; }
    public Comb(List<int> pokers)
    {
        length = pokers.Count;
        if(length == 1)
        {
            size = pokers[0];
            type = PokerType.Single;
            return;
        }
        type = IsSingle(pokers);
        if (type != PokerType.Without) return;
        type = IsDouble(pokers);
        if (type != PokerType.Without) return;
        type = IsThree(pokers);
        if (type != PokerType.Without) return;
        type = IsFour(pokers);
        if (type != PokerType.Without) return;
    }


    PokerType IsSingle(List<int> pokers)
    {
        if (length < 5) return PokerType.Without;
        for (int f = 0; f < pokers.Count - 1; f++)
        {
            if (pokers[f] != pokers[f + 1] - 1)
            {
                return PokerType.Without;
            }

        }
        size = pokers[0];
        return PokerType.Single;
    }

    PokerType IsDouble(List<int> pokers)
    {
        if (pokers.Count % 2 == 1) return PokerType.Without;
        for(int  f = 0; f < pokers.Count - 1; f +=2 )
        {
            if(pokers[f] != pokers[f + 1])
            {
                return PokerType.Without;
            }
            if(f < pokers.Count - 2)
            {
                if (pokers[f] != pokers[f + 2] - 1) return PokerType.Without;
            }
        }
        if (pokers.Count == 4) return PokerType.Without;
        size = pokers[0];
        return PokerType.Double;
    }

    PokerType IsThree(List<int> pokers)
    {
        int localLength = pokers.Count;
        if (localLength < 3) return PokerType.Without;
        
        //abcaaa
        if (pokers[localLength - 1] == pokers[localLength - 2] && 
            pokers[localLength - 2] == pokers[localLength - 3] && 
            6 > localLength && 
            localLength > 3)
        {
            pokers.Reverse();
        }
        //aaab or aaa or aaabb or aaabbb...
        if (pokers[1] == pokers[0] && pokers[1] == pokers[2])
        {
            if (localLength == 4 && pokers[2] != pokers[3])
            {
                size = pokers[0];
                localLength = 4;
                return PokerType.Three;
            }
            else if (localLength == 5)
            {
                size = pokers[0];
                if (pokers[3] != pokers[4])
                { 
                    return PokerType.Without;
                }
                return PokerType.Three;
            }
            else if(localLength == 3)
            {
                size = pokers[0];
                return PokerType.Three;
            }
            else
            {
                if (localLength % 3 != 0) return PokerType.Without;
                for(int f2 = 0; f2 < localLength/3; f2 ++)
                {
                    int first = f2 * 3;
                    if(pokers[first] != pokers[first + 1] || pokers[first + 1] != pokers[first + 2])
                    {
                        return PokerType.Without;
                    }
                    if(first + 3 >= pokers.Count)
                    {
                        break;
                    }
                    if(pokers[first] != pokers[first + 3] - 1)
                    {
                        return PokerType.Without;
                    }
                }
                size = pokers[0];
                return  PokerType.Three;
            }
            
            
        }
        return PokerType.Without;

    }

    PokerType IsFour(List<int> pokers)
    {
        if (pokers.Count % 4 != 0)
        {
            if (pokers.Count != 6)
            {
                return PokerType.Without;
            }
            if(pokers[0] == pokers[1] && pokers[1] == pokers[2] && pokers[2] == pokers[3] && pokers[4] == pokers[5])
            {
                size = pokers[0];
                return PokerType.FourAndTwo;
            }
            if (pokers[5] == pokers[4] && pokers[4] == pokers[3] && pokers[3] == pokers[2] && pokers[1] == pokers[0])
            {
                size = pokers[5];
                return PokerType.FourAndTwo;
            }
            return PokerType.Without;
        }
        for(int f = 0; f < pokers.Count/4; f ++)
        {
            int first = f * 4;
            if(pokers[first] != pokers[first + 1] && pokers[first + 1] != pokers[first + 2] && pokers[first + 2] != pokers[first + 3])
            {
                return PokerType.Without;
            }
            if(first + 4 >= pokers.Count)
            {
                break;
            }
            if(pokers[first] != pokers[first +  4] - 1)
            {
                return PokerType.Without;
            }
        }
        if (pokers.Count == 4)
        {
            size = pokers[0];
            return PokerType.Bomb;
        }
        return PokerType.MutipleFour;
    }
    public override string ToString()
    {
        return "type:" + type + "  size:" + size + "   length:" + length;
    }
}
