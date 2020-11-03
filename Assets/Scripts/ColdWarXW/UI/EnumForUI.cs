using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UIFormType
{
    //普通框体
    Normal,
    //固定框体(背景/可挂载非全屏弹出窗体)
    Fixed,
    //弹出框体
    PopUP
}
public enum UIFromShowMode
{
    //普通窗体，可与其他窗体并行显示
    Normal,
    //反向切换（弹出窗体）
    ReverseChange,
    //隐藏其他（显示时隐藏其他窗体）
    HideOther

}
public enum UIFromLucenyType
{
    //完全透明
    Luncency,
    //半透明，不能穿透
    Translucence,
    //低透明度，不能穿透
    ImPenetrable,
    //可以穿透
    Pentrate

}
public class EnumForUI : MonoBehaviour
{
  
}
