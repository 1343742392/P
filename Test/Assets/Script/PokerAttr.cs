using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;

public class PokerAttr : MonoBehaviour {
    public int size = 0;

    public int color = 0;
    private void Start()
    {
        string str = gameObject.name.Substring(gameObject.name.Length - 1, 1);
        switch (str)
        {
            case "0":
                size = 10;
                break;
            case "j":
                size = 11;
                break;
            case "q":
                size = 12;
                break;
            case "k":
                size = 13;
                break;
            case "a":
                size = 14;
                break;
            case "2":
                size = 15;
                break;
            default:
                size = int.Parse(Regex.Replace(gameObject.name, "[a-z]", "")); 
                break;
        }

        switch(Regex.Replace(gameObject.name.Substring(0, gameObject.name.Length - 1), "[0-9]", ""))
        {
            case "bh":
                this.color = 1;
                break;
            case "rh":
                this.color = 2;
                break;
            case "mei":
                this.color = 3;
                break;
            case "sq":
                this.color = 4;
                break;
            case "king":
                if (size == 16)
                    this.color = 5;
                else
                    this.color = 6;
                break;

        }
    }

}
