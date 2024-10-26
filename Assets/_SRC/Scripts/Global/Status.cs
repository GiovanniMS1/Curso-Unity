using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Status
{
    public int Health;
    public int Armor;
    public int MagicResist;

    public void Init()
    {
        Health = 9999999;
        Armor = 20;
        MagicResist = 20;
    }
}
