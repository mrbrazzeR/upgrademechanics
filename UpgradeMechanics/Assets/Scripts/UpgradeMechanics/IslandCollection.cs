using UnityEngine;

namespace UpgradeMechanics
{
    [CreateAssetMenu(menuName = "Building/Island",fileName = "IslandCollection",order = 0)]
    public class IslandCollection:ScriptableObject
    {
        public BuildingDetail[] island;
    }
}