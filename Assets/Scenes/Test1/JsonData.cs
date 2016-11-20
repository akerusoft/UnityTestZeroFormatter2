using UnityEngine;

[System.Serializable]
public class JsonData
{
    public const int VERSION1 = 1;
    public const int CURRENT_VERSION = VERSION1;

    public int Version = CURRENT_VERSION;
    public string Name;
    public uint HitPoint;
    public float HitRate;
    public uint Speed;
    public uint Luck;
}
