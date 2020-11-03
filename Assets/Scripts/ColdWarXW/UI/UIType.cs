using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class UIType 
{
    //是否反向切换（显示此页面时仅开放此页面的交互）
    public bool IsClearReverseChange = false;
    //窗口类型
    public UIFormType UIForm_Type = UIFormType.Normal;
    //显示模式
    public UIFromShowMode UIFrom_ShowMode = UIFromShowMode.Normal;
    //显示时透明度 
    public UIFromLucenyType UIFrom_LucenyType = UIFromLucenyType.Luncency;
}
