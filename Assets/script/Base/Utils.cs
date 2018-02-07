using UnityEngine;
namespace Utils
{
    public class MathUtil
    {

        public static float Angle(Vector3 point,Vector3 target)
        {
            GameObject cameraObj = GameObject.Find("Main Camera");
            Camera camera = cameraObj.GetComponent<Camera>();
            Vector3 p = camera.WorldToScreenPoint(point);
            Vector3 t = camera.WorldToScreenPoint(target);
            //p 为圆形 t为圆上一点
            float angle = Mathf.Atan2((p.y - t.y), (p.x - t.x)) * 180 / Mathf.PI;
            return angle;
        }


    }
}
