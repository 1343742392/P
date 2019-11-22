/*using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] int one = 0;
    [SerializeField] int two = 0;
    [SerializeField] int three = 0;
    [SerializeField] int four = 0;
    [SerializeField] int five = 0;
    [SerializeField] int six = 0;
    [SerializeField] int length = 6;


    void test(Action t)
    {
        t();
    }
    void Start()
    {
        test(delegate ()
        {

            Debug.Log("run");
        });
                List<int> ls = new List<int>();
                ls.Add(one);
                ls.Add(two);
                ls.Add(three);
                ls.Add(four);
                ls.Add(five);
                ls.Add(six);
                Debug.Log(new Comb(ls.GetRange(0, length)).ToString());



    }

    // Update is called once per frame
    void Update()
    {
*//*        List<int> ls = new List<int>();
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        ls.Add(Random.Range(0, 15));
        Debug.Log(new Comb(ls.GetRange(0, Random.Range(1, 8))).ToString());
        Debug.Log(ls.ToString());*//*
    }
}
*/



using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    public bool dragOnSurfaces = true;

    private GameObject m_DraggingIcon;
    private RectTransform m_DraggingPlane;
    void Update()
    {

       
    }

    private void OnGUI()
    {
       // GUI.TextArea(new Rect(new Vector2(0, 0), new Vector2(100, 100)), "test");
    }

    public void OnMouseMove()
    {
        Debug.Log(Input.GetMouseButton(0));
        if(Input.GetMouseButton(0)) Debug.Log("move");

    }

    public void OnMouseUp()
    {
        Debug.Log("up");

    }

   /* public void OnBeginDrag (PointerEventData eventData)
    {
        var canvas = FindInParents  <Canvas>(gameObject);
        if (canvas == null)
            return;

        // We have clicked something that can be dragged.
        // What we want to do is create an icon for this.
        m_DraggingIcon = new GameObject("icon");

        m_DraggingIcon.transform.SetParent(canvas.transform, false);
        m_DraggingIcon.transform.SetAsLastSibling();

        var image = m_DraggingIcon.AddComponent<Image>();
        // The icon will be under the cursor.
        // We want it to be ignored by the event system.
        CanvasGroup group = m_DraggingIcon.AddComponent<CanvasGroup>();
        group.blocksRaycasts = false;

        image.sprite = GetComponent<Image>().sprite;
        image.SetNativeSize();

        if (dragOnSurfaces)
            m_DraggingPlane = transform as RectTransform;
        else
            m_DraggingPlane = canvas.transform as RectTransform;

        SetDraggedPosition(eventData);
    }

    public void OnDrag (PointerEventData data)
    {
        if (m_DraggingIcon != null)
            SetDraggedPosition(data);
    }

    private void SetDraggedPosition (PointerEventData data)
    {
        if (dragOnSurfaces && data.pointerEnter != null && data.pointerEnter.transform as RectTransform != null)
            m_DraggingPlane = data.pointerEnter.transform as RectTransform;

        var rt = m_DraggingIcon.GetComponent<RectTransform>();
        Vector3 globalMousePos;
        if (RectTransformUtility.ScreenPointToWorldPointInRectangle(m_DraggingPlane, data.position, data.pressEventCamera, out globalMousePos))
        {
            rt.position = globalMousePos;
            rt.rotation = m_DraggingPlane.rotation;
        }
    }

    public void OnEndDrag (PointerEventData eventData)
    {
        if (m_DraggingIcon != null)
            Destroy(m_DraggingIcon);
    }

    static public T FindInParents <T>(GameObject go) where T : Component
    {
        if (go == null) return null;
        var comp = go.GetComponent<T>();

        if (comp != null)
            return comp;

        Transform t = go.transform.parent;
        while (t != null && comp == null)
        {
            comp = t.gameObject.GetComponent<T>();
            t = t.parent;
        }
        return comp;
    }*/

}

/*
ScrollRect scrollRect = GetComponent<ScrollRect>();
            if (scrollRect == null)
            {
                return;
            }

            if (scrollRect.verticalNormalizedPosition< 0)
            {
                wight.RequestNextPageKinList();
            }
            else
            {
                wight.m_ArrowDown.enabled = true;
            }
*/