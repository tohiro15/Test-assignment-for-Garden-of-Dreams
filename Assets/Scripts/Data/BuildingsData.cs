using System;
using UnityEngine;

[Serializable]
public class BuildingsData
{
    public BuildingData[] Buildings;
}

[Serializable]
public class BuildingData
{
    public int PrefabIndex;
    public Vector3 Position;
}