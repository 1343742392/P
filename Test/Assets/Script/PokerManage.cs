using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading;
using UnityEngine.UI;

public class PokerManage : MonoBehaviour
{
    Action back1;

    [SerializeField]  float interval = 30;
    [SerializeField] float distance = 225;
    [SerializeField] float outPokerDistance = 100;
    [SerializeField] float outPokerSclae = 0.8f;
    [SerializeField] GameObject alldPoker;
    public bool mIsNext = false;
    //手上的牌
    ArrayList pokers = new ArrayList();
    //添加牌时候的临时保存
    ArrayList bufferPokers = new ArrayList();
    //升起的牌
    ArrayList upPokers = new ArrayList();
    //已经出去的牌
    ArrayList outPokers = new ArrayList();
    Vector2 center;
    GameObject canvas;
    Animator animatior;
    String animationName;
    int addNum = 0;
    int index = 0;
    public bool outPokerAble = false;
    public float theyBackScale = 0.6f;
    GameObject buttonMange;
    float pokerWidth = 0;
    GameObject back;

    void Start()
    {
        outPokerAble = false;
        buttonMange = GameObject.Find("Buttons");
        back =Instantiate(GameObject.Find("back")) as GameObject;
        back.name = "back" + gameObject.name;
        pokerWidth = back.GetComponent<RectTransform>().rect.width;
        canvas = GameObject.Find("Canvas");
        center = new Vector2(canvas.GetComponent<RectTransform>().rect.width/2, canvas.GetComponent<RectTransform>().rect.height/2 + 50f);
        back.transform.parent = canvas.transform;
        back.transform.SetAsFirstSibling();
        switch (gameObject.name)
        {
            case "Player1":
                break;
            case "Player2":
                back.GetComponent<RectTransform>().localScale = new Vector3(theyBackScale, theyBackScale);
                break;
            default:
                back.GetComponent<RectTransform>().localScale = new Vector3(theyBackScale, theyBackScale);
                break;
        }
        animatior = back.GetComponent<Animator>();
    }

    void Update ()
    {


    }

   
 

    public void addPokers(ArrayList p, Action callback = null)
    {
        switch (gameObject.name)
        {
            case "Player1":
                animationName = "addPokerDown";
                break;
            case "Player2":
                animationName = "addPokerLeft";
                break;
            default:
                animationName = "addPokerRight";
                break;
        }
        back1 = callback;
        this.addNum = p.Count;

        animatior.Play(animationName);
        animatior.SetBool("loop", true);
        back.GetComponent<AnimaEvent>().mEndBack = addAnimaBack;

        Debug.Log(animatior == null);
        bufferPokers = p;
        for(int f = 0; f < p.Count; f ++)
        {
           if(gameObject.name!= "Player1")(p[f] as GameObject).transform.Rotate(0, 0, 90);
            (p[f] as GameObject).GetComponent<Poker>().player = gameObject;
        }
    }

    void addAnimaBack()
    {

            pokers.Add(bufferPokers[0]);
        bufferPokers.RemoveAt(0);
        pokers.Sort(new PokerSort());
        if (gameObject.name == "Player3") pokers.Reverse();
        index++;


        //animatior.Play(animationName);


        //定位手上的牌 
        float length = bufferPokers.Count;
        float first = center.x - (Math.Max(0, pokers.Count - 1) * interval) / 2;

        for (int f = 0; f < pokers.Count; f++)
        {
            RectTransform rt = (pokers[f] as GameObject).GetComponent<RectTransform>();
            Vector2 play1Pos = new Vector2(first + f * interval, center.y - distance);
            Vector2 localFirst = play1Pos - center;
            //旋转player1位置得到其他player位置
            switch (gameObject.name)
            {
                case "Player1":
                    rt.position = play1Pos;
                    break;
                case "Player2":
                    Vector3 firstPos = new Vector3(localFirst.x, localFirst.y - 75, 0);
                    firstPos = MathTool.Rotate(firstPos, Vector3.forward, -90);
                    rt.position = new Vector2(firstPos.x + center.x, firstPos.y + center.y);
                    break;
                default:
                    Vector3 firstPos2 = new Vector3(localFirst.x, localFirst.y - 75, 0);
                    firstPos = MathTool.Rotate(firstPos2, Vector3.forward, 90);
                    rt.position = new Vector2(firstPos.x + center.x, firstPos.y * -1f + center.y);
                    break;
            }
        }

        if (index == 5)
        {
            Sprite sprite = Resources.Load<Sprite>("img/allPoker2");
            if (sprite != null) alldPoker.GetComponent<Image>().sprite = sprite;
        }
        else if (index == 10)
        {
            Sprite sprite = Resources.Load<Sprite>("img/allPoker3");
            if (sprite != null) alldPoker.GetComponent<Image>().sprite = sprite;
        }
        if(index == 2 && alldPoker.GetComponent<AllPoker>().allPoker.Count == 0)
        {
            Destroy(alldPoker.GetComponent<Image>());
        }
        if(addNum - 1 == index)
        {
            animatior.SetBool("loop", false);
        }
        if (addNum == index)
        {
            index = 0;
            back.transform.position = new Vector3(1000, 1000);
            animatior.Play("null");
            if (back1 != null) back1();
        }
    }

    public void addUpPoker(GameObject poker)
    {
        upPokers.Add(poker);
        if(outPokerAble) buttonMange.GetComponent<ButtonManage>().SetButtons(new string[] {"outPoker", "next" }, outPokerBtnBack);

    }

    public void  rmUpPoker(GameObject poker)
    {
        upPokers.Remove(poker);
    }

    public void RefreshPoker()
    {


        float length = pokers.Count;
        float first = center.x - (Math.Max(0, pokers.Count - 1) * interval) / 2;

        for (int f = 0; f < pokers.Count; f++)
        {
            RectTransform rt = (pokers[f] as GameObject).GetComponent<RectTransform>();
            Vector2 play1Pos = new Vector2(first + f * interval, center.y - distance);
            Vector2 localFirst = play1Pos - center;
            //旋转player1位置得到其他player位置
            switch (gameObject.name)
            {
                case "Player1":
                    rt.position = play1Pos;
                    break;
                case "Player2":
                    Vector3 firstPos = new Vector3(localFirst.x, localFirst.y - 75, 0);
                    firstPos = MathTool.Rotate(firstPos, Vector3.forward, -90);
                    rt.position = new Vector2(firstPos.x + center.x, firstPos.y + center.y);
                    break;
                default:
                    Vector3 firstPos2 = new Vector3(localFirst.x, localFirst.y - 75, 0);
                    firstPos = MathTool.Rotate(firstPos2, Vector3.forward, 90);
                    rt.position = new Vector2(firstPos.x + center.x, firstPos.y * -1f + center.y);
                    break;
            }
        }
    }

    public void outPokerBtnBack(string result)
    {
        if (result == ButtonManage.ButtonNames.OutPoker)
        {
            buttonMange.GetComponent<ButtonManage>().SetButtons(new string[] { });
            List<int> l = new List<int>();
            foreach (GameObject gameObject in upPokers)
            {
                l.Add(gameObject.GetComponent<PokerAttr>().size);
            }
            Comb c = new Comb(l);
            if (!Judge.Legitimate(c))
            {
                Debug.Log("no");
                return;
            }
            outPokers.AddRange(upPokers);
            mIsNext = false;
            switch (gameObject.name)
            {
                case "Player1":
                    float first1 = center.x - (Math.Max(0, upPokers.Count - 1) * interval * outPokerSclae) / 2;
                    for (int f = 0; f < upPokers.Count; f++)
                    {
                        RectTransform rt = (upPokers[f] as GameObject).GetComponent<RectTransform>();
                        rt.position = new Vector2(first1 + f * interval * outPokerSclae, center.y - outPokerDistance);
                        rt.localScale = new Vector2(outPokerSclae, outPokerSclae);
                        pokers.Remove(upPokers[f]);
                    }

                    break;
                case "Player2":
                    float first2 = center.x - (Math.Max(0, upPokers.Count - 1) * interval * outPokerSclae) / 2;
                    for (int f = 0; f < upPokers.Count; f++)
                    {
                        RectTransform rt = (upPokers[f] as GameObject).GetComponent<RectTransform>();
                        Vector3 ps2 = new Vector2(first2 + f * interval * outPokerSclae, center.y - outPokerDistance);
                        rt.position = MathTool.Rotate(ps2, Vector3.forward, -90);
                        rt.localScale = new Vector2(outPokerSclae, outPokerSclae);
                        pokers.Remove(upPokers[f]);
                    }
                    break;
                case "Player3":
                    float first3 = center.x - (Math.Max(0, upPokers.Count - 1) * interval * outPokerSclae) / 2;
                    for (int f = 0; f < upPokers.Count; f++)
                    {
                        RectTransform rt = (upPokers[f] as GameObject).GetComponent<RectTransform>();
                        Vector3 ps3 = new Vector2(first3 + f * interval * outPokerSclae, center.y - outPokerDistance);
                        rt.position = MathTool.Rotate(ps3, Vector3.forward, 90);
                        rt.localScale = new Vector2(outPokerSclae, outPokerSclae);
                        pokers.Remove(upPokers[f]);
                    }
                    break;
            }
            Judge.beforePoker = c;
            alldPoker.GetComponent<AllPoker>().outPokerEnd(gameObject);
            upPokers.RemoveRange(0, upPokers.Count);
            RefreshPoker();
        }
        else
        {
            mIsNext = true;
        }
        

    }


}
