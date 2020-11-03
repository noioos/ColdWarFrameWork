using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResouseManager :SingletonManual<ResouseManager>
{
    /// <summary>
    /// 同步加载资源ByResources
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public T Load<T>(string name)where T:Object
    {
        T obj=Resources.Load<T>(name);
        if (obj is GameObject)
            return GameObject.Instantiate(obj);
        else
            return obj;
    }
    /// <summary>
    /// 异步加载资源
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void LoadAsyn<T>(string name, UnityAction<T> callback)where T:Object
    {
        MonoManager.Instance.StartCoroutine(Loadasyn(name,callback));
    }
    // 真 加载 
    private IEnumerator Loadasyn<T>(string name,UnityAction<T>callback)where T:Object
    {
        var resourceRequest=Resources.LoadAsync<T>(name);
        yield return null;

        if (resourceRequest.asset is GameObject)
            callback(GameObject.Instantiate<GameObject>(resourceRequest.asset as GameObject) as T);
        else
            callback(resourceRequest.asset as T);       
    }

}
