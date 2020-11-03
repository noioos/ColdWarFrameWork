using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventCenter : SingletonManual<EventCenter>
{
   //存储对应事件的相关订阅 
    private readonly Dictionary<string, UnityAction<BaseEventArgs>> eventDic = new Dictionary<string, UnityAction<BaseEventArgs>>();
    /// <summary>
    /// 添加对应事件的订阅 
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="action"></param>
    public void AddEventListener(string eventId,UnityAction<BaseEventArgs> action)
    {
        if (eventDic.ContainsKey(eventId))
            eventDic[eventId] += action;
        else
            eventDic.Add(eventId, action);
            
    }
    /// <summary>
    /// 移除对应事件的订阅
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="action"></param>
    public void RemoveEventListener(string eventId,UnityAction<BaseEventArgs>action)
    {
        eventDic.TryGetValue(eventId, out var evt);
        evt -= action;

    }
    /// <summary>
    /// 触发事件
    /// </summary>
    /// <param name="eventId"></param>
    /// <param name="args"></param>
    public void EventTigger(string eventId,BaseEventArgs args)
    {
        eventDic.TryGetValue(eventId, out var action);
        action?.Invoke(args);
            
    }
    /// <summary>
    /// 清空事件存储
    /// </summary>
    public void Clear()
    {
        eventDic.Clear();
    }

  
    
}
