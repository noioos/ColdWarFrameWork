using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PoolData
{
    public List<GameObject> poolList;
    public GameObject fatherObj;
    /// <summary>
    /// 构造一个指定类型的对象池，并把对象置入池中
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="poolObj">该对象池的父节点</param>
    public PoolData(GameObject obj,GameObject poolObj)
    {
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.parent = poolObj.transform;
        poolList = new List<GameObject> {};
        ReturnObj(obj);
    }
    /// <summary>
    /// 从池中取出一个对象
    /// </summary>
    /// <returns></returns>
    public GameObject GetObj()
    {
        GameObject obj = null;

        obj = poolList[0];
        poolList.RemoveAt(0);
        obj.transform.parent = null;
        obj.SetActive(true);
           
        return obj;
    }
    /// <summary>
    /// 将对象放入池中
    /// </summary>
    /// <param name="obj"></param>
    public void ReturnObj(GameObject obj)
    {
        obj.transform.parent = fatherObj.transform;
        obj.SetActive(false);
        poolList.Add(obj);
    }

}
public class PoolManager : MonoSingletoAuto<PoolManager>
{
    public static readonly Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();
    /// <summary>
    /// 从对象池中获取对象
    /// 如对象不存在，则从resource中加载该对象
    /// </summary>
    /// <param name="path">资源路径</param>
    /// <returns></returns>
    public  GameObject GetObj(string path)
    {
        GameObject obj = null;
        if (poolDic.ContainsKey(path) && poolDic[path].poolList.Count > 0)
            obj=poolDic[path].GetObj();
        else
        {
           obj =GameObject.Instantiate(Resources.Load<GameObject>(path));
            obj.name = path;
        }
        return obj;
         
    }
    /// <summary>
    /// 加载对象时使用异步加载 
    /// </summary>
    /// <param name="path"></param>
    /// <param name="callBack"></param>
    public void GetObj(string path,UnityAction<GameObject> callBack)
    {

        if (poolDic.ContainsKey(path) && poolDic[path].poolList.Count > 0)
            callBack(poolDic[path].GetObj());
        else
            ResouseManager.Instance.LoadAsyn<GameObject>(path, (o) => 
            {
                Debug.Log(path);
                o.name = path;
                callBack(o);
            });

            
    }
    /// <summary>
    /// 将对象置回对象池
    /// 如无对应的对象池，则创建一个该类型的池子
    /// </summary>
    /// <param name="path"></param>
    /// <param name="obj"></param>
    public  void ReturnhObj(string path,GameObject obj)
    {
        if (poolDic.ContainsKey(path))
            poolDic[path].ReturnObj(obj);
        else
            poolDic.Add(path, new PoolData(obj,gameObject));
    }
    public void Clear()
    {
        
    }


}
