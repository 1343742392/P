using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shere : MonoBehaviour {
    [SerializeField] bool old;
    static public Vector3 Rotate(Vector3 source, Vector3 axis, float angle)
    {

        Quaternion q = Quaternion.AngleAxis(angle, axis);// 旋转系数
        return q * source;
    }

    Vector3 RoteX(Vector3 value, float angle)
    {
        Matrix4x4 result = new Matrix4x4();
        result.SetRow(0, new Vector4(1f, 0f, 0f, 0f));
        result.SetRow(1, new Vector4(0f, Mathf.Cos(angle), -Mathf.Sin(angle), 0f));
        result.SetRow(2, new Vector4(0f, Mathf.Sin(angle), Mathf.Cos(angle), 0f));
        result.SetRow(3, new Vector4(0f, 0f, 0f, 1f));

        return result.MultiplyVector(new Vector4(value.x, value.y, value.z, 1));
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(RoteX(new Vector3(0.2f, 0.5f, 1), 3.14f/2));
        Debug.Log(Rotate(new Vector3(0.2f, 0.5f, 1),new Vector3(1, 0, 0), 90));
        if(old)
            transform.position = GameObject.Find("Cube").transform.position + Rotate(GameObject.Find("Cube").transform.forward,new Vector3(1,0,0), 90) * 2;
        else
            transform.position = GameObject.Find("Cube").transform.position + RoteX(GameObject.Find("Cube").transform.forward, 3.14f / 2) * 2;
    }
}
