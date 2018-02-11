using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    Dictionary<string, Queue<GameObject>> pool = new Dictionary<string, Queue<GameObject>>();


    public GameObject FindGameObject(string name)
    {
        name += "(Clone)";
        if (!pool.ContainsKey(name))
            return null;
        if (pool[name].Count == 0)
        {
            return null;
        }
        return pool[name].Dequeue();
    }



    public void AddToPool(GameObject obj)
    {
        if (pool.ContainsKey(obj.name) == false)
        {
            pool[obj.name] = new Queue<GameObject>();
        }
        obj.transform.position = new Vector3(0,0,0);
        obj.transform.rotation = new Quaternion(0, 0, 0, 0);

        obj.SetActive(false);
        Destroy(obj.GetComponent<BulletBase>());
        pool[obj.name].Enqueue(obj);
    }


}
