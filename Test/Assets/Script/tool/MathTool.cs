using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTool : MonoBehaviour {


    static public Vector3 Rotate(Vector3 source, Vector3 axis, float angle)
    {

        Quaternion q = Quaternion.AngleAxis(angle, axis);// 旋转系数
        return q * source;
    }

}
