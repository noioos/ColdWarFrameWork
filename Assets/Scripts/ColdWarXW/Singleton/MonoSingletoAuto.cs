using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingletoAuto<T> : MonoBehaviour where T:Component
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                var go = new GameObject();
                go.name = nameof(T);
                instance = go.AddComponent<T>();
                DontDestroyOnLoad(go);

            }

            return instance;
        }
    }
}
