using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Threading;
public class PokerManage : MonoBehaviour
{
    Action back1;

    [SerializeField]  float interval = 30;
    [SerializeField] float distance = 225;
    [SerializeField] float outPokerDistance = 100;
    [SerializeField] float outPokerSclae = 0.8f;
    [SerializeField] GameObject alldPoker;
    ArrayList pokers = new ArrayList();
    ArrayList bufferPokers = new ArrayList();
    ArrayList upPokers = new ArrayList();
    ArrayList outPokers = new ArrayList();
    Vector2 center;
    GameObject canvas;
    Animator animatior;
    String animationName;
    int addNum = 0;
    int index = 0;
    public bool outPokerAble = false;
    GameObject buttonMange;
    float pokerWidth = 0;

    void Start()
    {
        outPokerAble = false;
        buttonMange = GameObject.Find("Buttons");
        GameObject back =Instantiate(GameObject.Find("back")) as GameObject;
        pokerWidth = back.GetComponent<RectTransform>().rect.width;
        canvas = GameObject.Find("Canvas");
        center = new Vector2(canvas.GetComponent<RectTransform>().rect.width/2, canvas.GetComponent<RectTransform>().rect.height/2 + 50f);
        back.transform.parent = canvas.transform;
        back.transform.SetAsFirstSibling();
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
        animatior = back.GetComponent<Animator>();
        //GameObject obj = Instantiate(GameObject.Find("bh3")) as GameObject;
        //obj.GetComponent<RectTransform>().position = new Vector2(1000, 1000);
        //obj.GetComponent<RectTransform>().SetParent(canvas.GetComponent<RectTransform>());
        //addPoker(obj, back, starPokerNum);
    }

    void Update ()
    {
        if(this.addNum > 0)
        {
            float nt = animatior.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (nt - index > 1 && (!animatior.GetCurrentAnimatorStateInfo(0).IsName("null")))
            {
                //添加进pokers
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
                            firstPos =  MathTool.Rotate(firstPos, Vector3.forward, -90);
                            rt.position = new Vector2(firstPos.x + center.x, firstPos.y + center.y);
                            break;
                        default:
                            Vector3 firstPos2 = new Vector3(localFirst.x, localFirst.y - 75, 0);
                            firstPos = MathTool.Rotate(firstPos2, Vector3.forward, 90);
                            rt.position = new Vector2(firstPos.x + center.x, firstPos.y * -1f + center.y);
                            break;
                    }
                }

               
                if (addNum == index)
                {
                    animatior.Play("null");
                    if(back1!=null) back1();
                }
            }
        }

    }

   
 
    
    //public void addPoker(GameObject p, Action callback = null)
    //{
    //    back1 = callback;
    //    this.addNum = 1;
    //    animatior.Play("addPoker");
    //    Debug.Log("____"  + "    isAdd:" + animatior.GetCurrentAnimatorStateInfo(0).IsName("addPoker"));
    //    pokers.Add(p);
        
    //}

    public void addPokers(ArrayList p, Action callback = null)
    {
        back1 = callback;
        this.addNum = p.Count;
        animatior.Play(animationName);
        Debug.Log("____" + "    isAdd:" + animatior.GetCurrentAnimatorStateInfo(0).IsName("addPoker"));
        bufferPokers = p;
        for(int f = 0; f < p.Count; f ++)
        {
           if(gameObject.name!= "Player1")(p[f] as GameObject).transform.Rotate(0, 0, 90);
            (p[f] as GameObject).GetComponent<Poker>().player = gameObject;
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
        buttonMange.GetComponent<ButtonManage>().SetButtons(new string[] { });
        List<int> l = new List<int>();
        foreach(GameObject gameObject in upPokers)
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
        switch (gameObject.name)
        {
            case "Player1":
                float first1 = center.x - (Math.Max(0, upPokers.Count - 1) * interval * outPokerSclae) / 2;
                for(int f = 0; f < upPokers.Count; f ++)
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


}
