using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
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
        GameObject.Find("Canvas").GetComponent<Animator>().Play("StartFade");
        transform.position = new Vector3(1000, 1000);
        CallBack.Set(1, delegate ()
        {
            Application.LoadLevel("1");
        });
    }
}
