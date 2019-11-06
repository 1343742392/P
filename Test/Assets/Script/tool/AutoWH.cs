using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoWH : MonoBehaviour {
    void Log(object obj)
    {
        Debug.Log(obj);
    }

    public static void SetRectTransformSize(RectTransform trans, Vector2 newSize)
    {
        Vector2 oldSize = trans.rect.size;
        Vector2 deltaSize = newSize - oldSize;
        trans.offsetMin = trans.offsetMin - 
            new Vector2(deltaSize.x * trans.pivot.x, deltaSize.y * trans.pivot.y);
        trans.offsetMax = trans.offsetMax + 
            new Vector2(deltaSize.x * (1f - trans.pivot.x), deltaSize.y * (1f - trans.pivot.y));
    }

   

	// Use this for initialization
	void Start () {
        RectTransform rf = GetComponent<RectTransform>();
        rf.sizeDelta = new Vector2(200, 200);
    }
	
	// Update is called once per frame
	void Update () {

    }
}
