using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 
/// </summary>
public class MusicManger : MonoSingletonManual<MusicManger>
{
    public  float AudioBgmVolmuns = 1f;
    public  float AudioEffectVolmuns = 1f;
    public  float AudioBgmPitch = 1f;
    public  float AudioEffectPitch = 1;
    



    private readonly Dictionary<string, AudioClip> audioClipDic = new Dictionary<string, AudioClip>();
    public  override void Awake()
    {
        base.Awake();
        

    }





}
