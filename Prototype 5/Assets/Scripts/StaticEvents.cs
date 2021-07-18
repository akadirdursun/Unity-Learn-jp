using UnityEngine;
using System;
using System.Collections.Generic;

public static class StaticEvents
{
    public delegate void VoidDelegate();    
    public static VoidDelegate GameOver;

    public static Action<int> AddScore;
    public static Action<float> StartTheGame;
}
