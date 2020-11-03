using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    private int level = 0;
    [SerializeField]
    private int exp = 0;
    public int Exp
    {
        get { return exp; }
        set
        {
            
            if (exp+value> 100)
            {
                level += (exp + value) / 100;
                exp = (exp + value) % 100;
            }
            else
            {
                exp += value;
            }
        }
    }
    public int coin = 0;


    public void Start()
    {
        var noi = InputManager.Instance;
        EventCenter.Instance.AddEventListener("nmsl", KillMonster);
        EventCenter.Instance.AddEventListener("on-key-code-trigger", Move);
        Debug.Log("player");
    }


    public void Move(BaseEventArgs args)
    {
        
        if (args is InputEventArgs _args)
            Debug.Log($"code is:{_args.code}  status is:{_args.status}");
    }

    public void KillMonster(BaseEventArgs args)
    {
        //TestMonsterArgs _args;
        if (args is TestMonsterArgs _args)
        {
            coin += _args.coins;
            Exp += _args.exp;
        }
        else
        {
            
            return;
        }

        


    }
}
