using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class GameData
{
    public Vector3 position;
    public Quaternion quaternion;
    public int iiint;

    public GameData()
    {
        iiint = 1;
        position = new Vector3(0,0,0);
        quaternion = Quaternion.identity;
    }
}
