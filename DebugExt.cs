/**************************************************************** 
*   DebugExt.cs
*   David Zulic - 2019
*   MIT License (check included License.md for details)
*****************************************************************/

using UnityEngine;

//Debug "extension" class
public static class DebugExt
{
   const int MinSegmentsCount = 8;
   const int DefaultSegmentsCount = 32;
   const float DefaultRadius = 1f;

   /// <summary>
   /// Draw a Debug Circle with a following parameters
   /// </summary>
   /// <param name="center">Circle center</param>
   /// <param name="faceAxis">Circle facing/pivot axis</param>
   /// <param name="radius">Circle radius</param>
   /// <param name="color">Circle color</param>
   /// <param name="segments">Circle arc segments</param>
   public static void DrawCircle(Vector3 center, Vector3 faceAxis, float radius, Color color, int segments = DefaultSegmentsCount)
   {
       segments = segments >= MinSegmentsCount ? segments : MinSegmentsCount;

       Quaternion rotation = Quaternion.FromToRotation(Vector3.forward, faceAxis);

       Vector3[] points = new Vector3[segments];

       float radPerSegment = (360f / (segments - 1)) * Mathf.Deg2Rad;

       for(int i = 0; i < segments; i++)
       {
           points[i] = new Vector3(Mathf.Cos(radPerSegment * i), Mathf.Sin(radPerSegment * i), 0) * radius;
       }

       Vector3[] alignedPoints = new Vector3[segments];
       Matrix4x4 m = Matrix4x4.Rotate(rotation);

       for (int i = 0; i < segments; i++)
       {
           alignedPoints[i] = m.MultiplyPoint3x4(points[i]) + center;
       }

       for (int i = 1; i < segments; i++)
       {
           Debug.DrawLine(alignedPoints[i - 1], alignedPoints[i], color);
       }
   }

   /// <summary>
   /// Draw a Debug Sphere with a following parameters
   /// </summary>
   /// <param name="center">Sphere center</param>
   /// <param name="fwd">Sphere forward vector</param>
   /// <param name="up">Sphere up vector</param>
   /// <param name="radius">Sphere radius</param>
   /// <param name="color">Sphere color</param>
   /// <param name="segments">Sphere arc segments (per disc/circle)</param>
   public static void DrawSphere(Vector3 center, Vector3 fwd, Vector3 up, float radius, Color color, int segments = DefaultSegmentsCount)
   {
       DrawCircle(center, fwd, radius, color, segments);
       DrawCircle(center, up, radius, color, segments);
       DrawCircle(center, Vector3.Cross(fwd, up), radius, color, segments);
   }

   #region DrawCircle convenience methods
   public static void DrawCircle(Vector3 center, float radius, Color color, int segments = DefaultSegmentsCount)
   {
       DrawCircle(center, Vector3.forward, radius, color, segments);
   }
   public static void DrawCircle(Vector3 center, Vector3 faceAxis, float radius)
   {
       DrawCircle(center, faceAxis, radius, Color.white, DefaultSegmentsCount);
   }
   public static void DrawCircle(Vector3 center, Vector3 faceAxis)
   {
       DrawCircle(center, faceAxis, DefaultRadius, Color.white, DefaultSegmentsCount);
   }
   public static void DrawCircle(Vector3 center, float radius, int segments = DefaultSegmentsCount)
   {
       DrawCircle(center, Vector3.forward, radius, Color.white, segments);
   }
   public static void DrawCircle(Vector3 center, float radius)
   {
       DrawCircle(center, Vector3.forward, radius, Color.white, DefaultSegmentsCount);
   }
   public static void DrawCircle(Vector3 center)
   {
       DrawCircle(center, Vector3.forward, DefaultRadius, Color.white, DefaultSegmentsCount);
   }
   #endregion

   #region DrawSphere convenience methods
   public static void DrawSphere(Vector3 center, Vector3 fwd, Vector3 up, float radius)
   {
       DrawSphere(center, Vector3.forward, Vector3.up, radius, Color.white, DefaultSegmentsCount);
   }

   public static void DrawSphere(Vector3 center, Vector3 fwd, Vector3 up)
   {
       DrawSphere(center, Vector3.forward, Vector3.up, DefaultRadius, Color.white, DefaultSegmentsCount);
   }

   public static void DrawSphere(Vector3 center, float radius, Color color, int segments = DefaultSegmentsCount)
   {
       DrawSphere(center, Vector3.forward, Vector3.up, radius, color, segments);
   }

   public static void DrawSphere(Vector3 center, float radius)
   {
       DrawSphere(center, Vector3.forward, Vector3.up, radius, Color.white, DefaultSegmentsCount);
   }

   public static void DrawSphere(Vector3 center)
   {
       DrawSphere(center, Vector3.forward, Vector3.up, DefaultRadius, Color.white, DefaultSegmentsCount);
   }
   #endregion
}
