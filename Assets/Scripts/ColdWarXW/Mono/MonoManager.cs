using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum MonoEventType
{

    Enable,
    Update,
    FixedUpdate,

}
public class MonoManager : MonoSingletonManual<MonoManager> {

    
    //存储对应声明周期需要调用的方法 
    private event UnityAction On_Enable;
    private event UnityAction On_Update;
    private event UnityAction On_FixedUpdate;

   /// <summary>
   /// 添加调用方法至相应生命周期中
   /// </summary>
   /// <param name="type"></param>
   /// <param name="unityAction"></param>
   public void On(MonoEventType type,UnityAction unityAction)
   {
        switch (type)
        {
           
            case MonoEventType.Enable:
                On_Enable += unityAction;
                break;
           
               
            case MonoEventType.Update:
                On_Update += unityAction;
                break;
            case MonoEventType.FixedUpdate:
                On_FixedUpdate += unityAction;
                break;
           
            default:
                break;
        }

    }
    /// <summary>
    /// 添加调用方法至相应生命周期中
    /// </summary>
    /// <param name="typeName"></param>
    /// <param name="unityAction"></param>
    public void On(string typeName,UnityAction unityAction)
    {
        if (Enum.TryParse<MonoEventType>(typeName, out var result))
            On(result, unityAction);
        else
            //抛出异常-试图将无效的枚举值传递给方法 
            throw new InvalidEnumArgumentException($"未定义的枚举类型 {typeName}");

    }

    /// <summary>
    /// 移除对应生命周期中的方法
    /// </summary>
    /// <param name="eventType"></param>
    /// <param name="unityAction"></param>
    public void Off(MonoEventType eventType, UnityAction unityAction)
    {
        switch (eventType)
        {
           
            case MonoEventType.Enable:
                On_Enable -= unityAction;
                break;
            
            case MonoEventType.Update:
                On_Update -= unityAction;
                break;
            case MonoEventType.FixedUpdate:
                On_FixedUpdate -= unityAction;
                break;
            
                
            
                
            default:
                break;
        }
    }
    /// <summary>
    /// 开启协程
    /// </summary>
    /// <param name="enumerator"></param>
    /// <returns></returns>
    public new Coroutine StartCoroutine(IEnumerator enumerator)
    {
        return base.StartCoroutine(enumerator);
    }
    /// <summary>
    /// 停止协程
    /// </summary>
    /// <param name="enumerator"></param>
    public new void StopCoroutine(IEnumerator enumerator)
    {
        base.StopCoroutine(enumerator);
    }
    
    //在对应生命周期中调用相应的方法 
    private void OnEnable()
    {
        On_Enable?.Invoke();
    }

    private void Update()
    {
        On_Update?.Invoke();
       
    }

    private void FixedUpdate()
    {
        On_FixedUpdate?.Invoke();
    }

   





}
