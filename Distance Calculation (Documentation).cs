//https://docs.unity3d.com/ScriptReference/Vector3.Distance.html
//https://docs.unity3d.com/Manual/DirectionDistanceFromOneObjectToAnother.html

//--Vector3.Distance
public static float Distance(Vector3 a, Vector3 b);

//--Description
//Returns the distance between a and b.

Vector3.Distance(a,b) is the same as (a-b).magnitude.

//----------------------
using UnityEngine;
using System.Collections;

public class ExampleClass : MonoBehaviour
{
    public Transform other;

    void Example()
    {
        if (other)
        {
            float dist = Vector3.Distance(other.position, transform.position);
            print("Distance to other: " + dist);
        }
    }
}
//--------------------
