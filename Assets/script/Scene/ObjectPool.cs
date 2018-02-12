using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPool : MonoBehaviour {

    
    Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();

    /// <summary>
    /// 从池中获得obj
    /// </summary>
    /// <param name="name">名字</param>
    /// <returns></returns>
    public GameObject FindGameObject(string name)
    {
        
        if (!pool.ContainsKey(name))
            return null;
        if (pool[name].Count == 0)
        {
            return null;
        }
        return pool[name].Dequeue();
    }

    private void ResetObj(GameObject obj)
    {
        //初始化
        obj.SetActive(false);
        foreach(var sc in obj.GetComponents<BulletBase>())
        {
            Destroy(sc);
        }
    }
    /// <summary>
    /// 增加到池中
    /// </summary>
    /// <param name="obj"></param>
    public void AddToPool(GameObject obj)
    {
        string temName = obj.name;
        if (pool.ContainsKey(temName) == false)
        {
            pool[obj.name] = new Queue<GameObject>();
        }
        ResetObj(obj);
        //GameObject.Find("Text").GetComponent<Text>().text = pool[temName].Count.ToString();
        pool[temName].Enqueue(obj);
    }


}
