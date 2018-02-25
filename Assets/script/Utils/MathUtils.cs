using UnityEngine;
using System.Collections;


namespace Utils
{
    public class MathUtils
    {
        /// <summary>
        /// 旋转向量
        /// (顺时针)
        /// </summary>
        /// <param name="v">原向量</param>
        /// <param name="angle">角度</param>
        /// <returns></returns>
        public static Vector3 RotationMatrix(Vector3 v, float angle)
        {
            var x = v.x;
            var y = v.y;
            var sin = Mathf.Sin(Mathf.PI * angle / 180);
            var cos = Mathf.Cos(Mathf.PI * angle / 180);
            var newX = x * cos + y * sin;
            var newY = x * -sin + y * cos;
            return new Vector3(newX, newY, 0f);
        }
    }

}
