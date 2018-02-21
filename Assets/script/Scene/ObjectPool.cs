using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPool : MonoBehaviour {

    
    Dictionary<string, ConcurrentQueue<GameObject>> pool = new Dictionary<string, ConcurrentQueue<GameObject>>();



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
        GameObject tryOut;
        pool[name].TryDequeue(out tryOut);
        return tryOut;
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
            pool[obj.name] = new ConcurrentQueue<GameObject>();
        }
        obj.SetActive(false);
        obj.transform.parent = this.transform;
        BulletBase blt = obj.GetComponent<BulletBase>();
        if (blt!=null)
            blt.ResetScript();

        pool[temName].Enqueue(obj);
    }


}
