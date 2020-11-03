using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BaseUIFrom : MonoBehaviour
{
    private UIType _CurrentUIType = new UIType();
    //当前的UI类型信息 
    internal UIType CurrentUIType
    {
        set
        {
            _CurrentUIType = value;
        }
        get
        {
            return _CurrentUIType;
        }
    }

    //页面组件
    Dictionary<string, List<UIBehaviour>> controlDic = new Dictionary<string, List<UIBehaviour>>();
    
    /// <summary>
    /// 找到子对象的所有控件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void FindChildrenControl<T>()where T : UIBehaviour
    {
        T[] controls = this.GetComponentsInChildren<T>();
        string objName;
        foreach (var item in controls)
        {
            objName = item.gameObject.name;
            if (controlDic.ContainsKey(objName))
                controlDic[objName].Add(item);
            else
            {
                controlDic.Add(objName, new List<UIBehaviour>() { item });
            }

        }
    }
    /// <summary>
    /// 获得对应控件
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objName"></param>
    /// <returns></returns>
    public T GetControl<T>(string objName)where T : UIBehaviour
    {
        foreach (var item in controlDic[objName])
        {
            if (item is T)
                return item as T;
        }
        return null;
    }

    
    /// <summary>
    /// 页面显示
    /// </summary>
    public virtual void Display()
    {
        this.gameObject.SetActive(true);
    }
    /// <summary>
    /// 页面隐藏
    /// </summary>    
    public virtual void Hiding()
    {
        this.gameObject.SetActive(false);
    }
    /// <summary>
    /// 页面重新显示 
    /// </summary>
    public virtual void ReDisplay()
    {
        this.gameObject.SetActive(true);
    }
    /// <summary>
    /// 页面冻结（还在栈集合中）
    /// </summary>
    public virtual void Freeze()
    {
        this.gameObject.SetActive(true);
    }
}
