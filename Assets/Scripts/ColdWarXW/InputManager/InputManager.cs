using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum KeyStatus
{
    Down,
    Up,
    Hold
}
public class InputEventArgs : BaseEventArgs
{
    public string eventId;
    public KeyCode code;
    public KeyStatus status;

    public InputEventArgs() { }

    public InputEventArgs(string eventId,KeyCode code,KeyStatus status)
    {
        this.eventId = eventId;
        this.code = code;
        this.status = status;

    }
}
public class InputManager : SingletonManual<InputManager>
{
    public const string KeyCodeEventId = "on-key-code-trigger";

    private bool enable = true;

    public InputManager()
    {
        MonoManager.Instance.On(MonoEventType.Update, DetectedInput);
       
    }
    private void DetectedInput()
    {
        if (!enable) return;
        
        if(!string.IsNullOrEmpty(Input.inputString))
            if(System.Enum.TryParse<KeyCode>(Input.inputString,true,out var code))
            {             
                
                CheckKeyCode(code);
                return;
            }
        

    }
    public void SetEnable(bool isEnable)
    {
        enable = isEnable;
    }
    private void CheckKeyCode(KeyCode code)
    {
        KeyStatus status = 0;


        if (Input.GetKeyDown(code))
        {
            status = KeyStatus.Down;
            var args = new InputEventArgs(KeyCodeEventId, code, status);
            EventCenter.Instance.EventTigger(KeyCodeEventId, args);
        }
        
        if (Input.GetKey(code))
        {
            status = KeyStatus.Hold;
            var args = new InputEventArgs(KeyCodeEventId, code, status);
            EventCenter.Instance.EventTigger(KeyCodeEventId, args);
        }

    }

}
