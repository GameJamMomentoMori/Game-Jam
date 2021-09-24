using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat
{
    [SerializeField]
    private int baseVal;

    private List<int> mods = new List<int>();

    public int getVal() {
        int finalVal = baseVal;
        mods.ForEach(x => finalVal += x);
        return finalVal;
    }

    public void AddMod(int mod) {
        if (mod != 0) {
            mods.Add(mod);
        }
    }

    public void RemoveMod(int mod) {
        if (mod != 0) {
            mods.Remove(mod);
        }
    }

}
