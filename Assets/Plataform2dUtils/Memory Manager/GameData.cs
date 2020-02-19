using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class GameData
{
    [SerializeField]
    Player player;

    public Player GetPlayer
    {
        get => player;
        set => player = value;
    }

}
