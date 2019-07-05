/**************************************************************** 
*   CirclesExample.cs
*   David Zulic - 2019
*   MIT License (check included License.md for details)
*****************************************************************/

using UnityEngine;

public class CirclesExample : MonoBehaviour
{
    void Update()
    {
        //Draw a circle facing one of global direction, with various parameters
        DebugExt.DrawCircle(Vector3.zero, Vector3.forward, 0.1f, Color.red);
        DebugExt.DrawCircle(Vector3.right, Vector3.up, 0.2f, Color.red);
        DebugExt.DrawCircle(Vector3.right * 2, Vector3.right, 0.4f, Color.red);

        //Draw a circle facing an arbitrary direction
        Vector3 randomVector = new Vector3(Random.value, Random.value, Random.value);
        DebugExt.DrawCircle(Vector3.right * 3, randomVector, 0.4f, Color.blue);

        //Draw a sphere facing global forward direction, with various parameters
        DebugExt.DrawSphere(Vector3.up, 0.01f, Color.magenta);
        DebugExt.DrawSphere(Vector3.up + Vector3.right, 0.05f, Color.magenta);
        DebugExt.DrawSphere(Vector3.up + Vector3.right * 2, 0.1f, Color.magenta);
        DebugExt.DrawSphere(Vector3.up + Vector3.right * 3, 0.5f, Color.magenta);

        //Draw a sphere facing an arbitrary direction
        DebugExt.DrawSphere(Vector3.up * 3, transform.forward, transform.up, 0.2f, Color.cyan, 32);
    }
}
