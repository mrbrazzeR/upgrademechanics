using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Building/Upgrade",fileName = "BuildingCollection",order = 0)]
public class BuildingUpgradeCollection : ScriptableObject
{
    public IslandInfo[] islandInfoCollection;

    public IslandInfo GetCurrentIslandInfo(int level)
    {
        return islandInfoCollection[level - 1];
    }
}

[Serializable]
public class IslandInfo
{
    public int level;
    public int numberOfBuildings;
    public BuildingInfoCollect[] buildingInfo;

}

[Serializable]
public class BuildingInfoCollect
{
    public string buildingName;
    public BuildingInfo[] data;
}

[Serializable]
public class BuildingInfo
{
    public int level;
    public int cost;
    public Sprite buildingImage;
}
