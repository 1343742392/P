using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Poker : MonoBehaviour
{
    [SerializeField] GameObject imgObj;
    public GameObject player = null;

    bool mClickAble = true;
    private Sprite mBackup;

    // Use this for initialization
    void Start () {


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseDw()
    {
        Debug.Log("down");
        Response();
    }

    public void OnMouseInter()
    {
        Debug.Log(Input.GetMouseButton(0));
        if (Input.GetMouseButton(0))
        {
            Debug.Log("inter");
            Response();

        }
    }
    public void Response()
    {
        if (!mClickAble) return;
        Animator imgAnim = imgObj.GetComponent<Animator>();
        if (imgAnim.GetCurrentAnimatorStateInfo(0).IsName("pokerUp") && imgAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >=0.99f)
        {
            player.GetComponent<PokerManage>().rmUpPoker(gameObject);
            imgAnim.Play("pokerInter");
        }
        else
        {
            if (imgAnim.GetCurrentAnimatorStateInfo(0).IsName("pokerUp"))
                return;
            player.GetComponent<PokerManage>().addUpPoker(gameObject);
            imgAnim.Play("pokerUp");
        }
        
    }

    public void SetImage(Sprite img)
    {
        if (imgObj != null)
        {
            imgObj.GetComponent<Image>().sprite = img;
        }
        else
        {
            Debug.Log("unset imgObj");
        }

    }

    public void Turn()
    {
        Sprite back = GameObject.FindWithTag("back").GetComponent<Image>().sprite;
        Image nowImg = imgObj.GetComponent<Image>();
        if(nowImg.sprite == back)
        {
            nowImg.sprite = mBackup;
        }
        else
        {
            mBackup = nowImg.sprite;
            nowImg.sprite = back;
        }
    }

    public void ClickAble(bool value)
    {
        mClickAble = value;
    }

}
