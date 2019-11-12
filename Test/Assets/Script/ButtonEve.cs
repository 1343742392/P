using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonEve : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnClick()
    {
        GameObject.Find("Buttons").GetComponent<ButtonManage>().SetResult(gameObject.name);
        switch (gameObject.name)
        {
            case "beLandlord":
                GameObject.Find("Judge").GetComponent<Judge>().AddOdds(2);
                /*           GameObject player2 = GameObject.Find("Player2");
                           GameObject player3 = GameObject.Find("Player3");
                           result = gameObject.name;*/
                
                
                break;
            case "doNot":


                break;
            default:
                break;
        }
    }


}
