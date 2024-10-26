using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExperience : MonoBehaviour
{
    public int NeededExperience;
    public int CurrentExperience;
    public PlayerWeapons weaponsScript;

    private void Start()
    {
        weaponsScript = GetComponent<PlayerWeapons>();
    }
    public void LevelUP()
    {
        CurrentExperience = 0;

        NeededExperience += 20;

        weaponsScript.AddRandomWeapon();
    }

    public void IncreaseXP(int amount)
    {
        CurrentExperience += amount;

        if (CurrentExperience >= NeededExperience)
        {
            LevelUP();
        }
    }
}
