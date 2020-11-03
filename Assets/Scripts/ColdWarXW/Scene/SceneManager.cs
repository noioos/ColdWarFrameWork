using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

// 场景加载信息
public class SceneLoadEvenrArgs:BaseEventArgs
{
    public float progress;
    public string EventId;
    public SceneLoadEvenrArgs() { }
    public SceneLoadEvenrArgs(string EventId,float progress)
    {
        this.progress = progress;
        this.EventId = EventId;
    }
   

}
public class SceneManager : MonoSingletonManual<SceneManager>
{
    
    private const string EventId = "on-scene-load-progress-update";
    private const string MidLordScene = "LoadScene_1";
    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="name">场景名</param>
    /// <param name="isAsync">是否异步加载</param>
    /// <param name="callback">回调函数</param>
    /// <param name="autoChange">是否自动切换</param>
    public void LoadScene(string name,bool isAsync=true,UnityAction callback=null,bool autoChange=true)
    {
        if (isAsync)
        {
            MonoManager.Instance.StartCoroutine(LoadSceneAsync(name, callback,autoChange));
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(name);
            callback?.Invoke();
        }
    }
    //真 异步加载场景
    private IEnumerator LoadSceneAsync(string name,UnityAction callblack,bool autoChange)
    {

        
        UnityEngine.SceneManagement.SceneManager.LoadScene(MidLordScene);       
        yield return null;

        AsyncOperation async = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(name);
        async.allowSceneActivation = autoChange;

        while (!async.isDone)
        {
            SceneLoadEvenrArgs args = new SceneLoadEvenrArgs(EventId, async.progress);
            EventCenter.Instance.EventTigger(EventId, args);
            Debug.Log(args.progress);
            yield return null;
        }

        yield return null;
        callblack?.Invoke();
        
    }
 
    


}
