using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonGameAppicationManager : Singleton<SingletonGameAppicationManager >
{
    public string[] DIFFICULTY_LEVEL_NAMES={"Easy","Normal","Hard","Extreme"};
    public bool IsOptionMenuActive
    {
        get{
            return _isOptionMenuActive;
        }
        set
        {
            _isOptionMenuActive = value;
        }
    }
    protected bool _isOptionMenuActive = false;
    public int DifficultyLevel{get;set;}
    public bool MusicEnabled { get; set; } = true;
    public bool SFXEnabled{get;set;} = true;



  
}
