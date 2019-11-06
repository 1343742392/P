using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public const int ADD = 1;
    public const int LOSS = 2;


    static public float CycleLimit(float source, float obj, float min, float max, int operation)
    {
        if (source < min || source > max)
        {
            Debug.Log("非正常输入");
            return 0;
        }
        switch (operation)
        {
            case ADD:
                if (source + obj > max)
                {
                    return min + (source + obj) - max;
                }
                else if (source + obj < min)
                {
                    return max - min + (source + obj);
                }
                return source + obj;
            case LOSS:
                break;
        }
        return 0;
    }

    static public Vector3 Rotate(Vector3 rotation, Vector3 source, Vector3 axis, float angle)
    {
        float axisX = Mathf.Abs(axis.x - (90 - Mathf.Abs(rotation.x % 180 - 90)) / 90);
        float axisY = Mathf.Abs(axis.y - (90 - Mathf.Abs(rotation.y % 180 - 90)) / 90);
        float axisZ = Mathf.Abs(axis.z - (90 - Mathf.Abs(rotation.z % 180 - 90)) / 90);
        Debug.Log(axisX + "  " + axisY + "  " + axisZ);
        Quaternion q = Quaternion.AngleAxis(angle, new Vector3(axisX, axisY, axisZ));// 旋转系数
        return q * source;
    }
    // Use this for initialization
    void Start()
    {



    }


    static public Vector3 Rotate(Vector3 source, Vector3 axis, float angle)
    {

        Quaternion q = Quaternion.AngleAxis(angle, axis);// 旋转系数
        return q * source;
    }

    float getAxis(float axis, float rotation)
    {

    }
  
    void Update()
    {
        Vector3 inputAxis = new Vector3(1, 0, 0);

        Vector3 axis;
        float angle;
        transform.rotation.ToAngleAxis(out angle, out axis);
        Vector3 rotation = angle * axis;
        float axisX = (90 - Mathf.Abs(rotation.x % 180 - 90)) / 90;
        float axisY = (90 - Mathf.Abs(rotation.y % 180 - 90)) / 90;
        float axisZ = (90 - Mathf.Abs(rotation.z % 180 - 90)) / 90;

        Debug.Log()
/*
        Debug.Log("axis;" + axisX + ";" + axisY + ";" + axisZ + ";" + "input" + rotation + "out" + 
            new Vector3(
                getAxis(inputAxis.x, axisZ),
                getAxis(inputAxis.y, (axisX + axisZ) / 2),
                getAxis(inputAxis.z, (axisX + axisY) / 2)
                ));
                */

    }
}
