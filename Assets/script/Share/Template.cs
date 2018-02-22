using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Share
{
    static class Template
    {
        static Dictionary<string, GameObject> _resourcePool = new Dictionary<string, GameObject>();
        /// <summary>
        /// 加载所有资源
        /// 需要在场景 GetTemplate调用前完成
        /// </summary>
        /// <param name="files">需要加载的文件夹列表</param>
        public static void LoadAllResources(string[] files)
        {
            //存到_resourcePool中
            for (int i = 0; i < files.Length; i++)
            {
                var list = Resources.LoadAll(files[i]);
                for(int j = 0; j < list.Length; j++)
                {
                    _resourcePool[list[j].name] = (GameObject)list[j];
                }
            }

        }
        /// <summary>
        /// 加载Bullet Character Other文件夹下的资源
        /// 需要在场景 GetTemplate调用前完成
        /// </summary>
        public static void LoadAllResources()
        {
            LoadAllResources(new string[] { "Bullet","Character","Other"});
        }
        /// <summary>
        /// 获得Template资源
        /// </summary>
        /// <param name="name">样板名</param>
        /// <returns></returns>
        public static GameObject GetTemplate(string name)
        {
            return _resourcePool[name];
        }

    }
}

