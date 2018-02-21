using System.Collections.Generic;
using UnityEngine;

namespace Utils
{
    public static class TransformUtils
    {

        public static void PushObjLength(GameObject obj, float len)
        {
            obj.transform.position += obj.transform.up * len;
        }

        public static void PushObjLength(List<GameObject> objList,float len)
        {
            objList.ForEach(obj => PushObjLength(obj, len));
        }






    }
}
