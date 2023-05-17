using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UpgradeMechanics
{
    public class UpdateBuildingMechanics : MonoBehaviour
    {
        public BuildingUpgradeCollection collection;
        public BuildingDetail buildingDetail;
        public IslandCollection islandCollection;
        public IslandInfo current;
        public int currentLevel;
        public int money;


        [Header("UI")] public Button upgradeButton;

        private void Awake()
        {
            CreateIsland();
            SetBuilding();
            upgradeButton.onClick.AddListener(CreateNewIsland);
        }

        #region Island Action

        private void CreateIsland()
        {
            var obj = Instantiate(islandCollection.island[currentLevel], transform);
            buildingDetail = obj;
            foreach (var building in buildingDetail.buildings)
            {
                Upgrade(building);
            }

            SetBuilding();
        }

        private void RemoveIsland()
        {
            foreach (var building in buildingDetail.buildings)
            {
                RemoveEvent(building);
            }

            Destroy(buildingDetail.gameObject);
            currentLevel++;
        }

        #endregion

        #region Events

        private void Upgrade(Building building)
        {
            building.OnPublish += OnUpgrade;
        }

        private void RemoveEvent(Building building)
        {
            building.OnPublish -= OnUpgrade;
        }

        private void CreateNewIsland()
        {
            RemoveIsland();
            CreateIsland();
            upgradeButton.gameObject.SetActive(false);
        }

        #endregion


        private void OnUpgrade(Building building)
        {
            var info = new BuildingInfoCollect();
            current = collection.GetCurrentIslandInfo(currentLevel);
            foreach (var build in current.buildingInfo)
            {
                if (build.buildingName == building.buildingName)
                {
                    info = build;
                }
            }

            if (money - info.data[building.currentLevel].cost >= 0)
            {
                if (building.currentLevel + 1 < info.data.Length)
                {
                    money -= info.data[building.currentLevel].cost;
                    building.currentLevel++;
                    building.SetSprite(info.data[building.currentLevel].buildingImage);
                }
            }

            SetBuilding();
            if (CheckFullUpgrade()&&currentLevel+1<islandCollection.island.Length)
            {
                upgradeButton.gameObject.SetActive(true);
            }
        }

        private void SetBuilding()
        {
            current = collection.GetCurrentIslandInfo(currentLevel);
            foreach (var build in current.buildingInfo)
            {
                foreach (var building in buildingDetail.buildings)
                {
                    if (build.buildingName == building.buildingName)
                    {
                        building.SetSprite(build.data[building.currentLevel].buildingImage);
                    }

                    CheckUpgradeCost(building, build);
                    CheckUpgradePossible(building, build);
                }
            }
        }

        #region Conditions

        private void CheckUpgradePossible(Building building, BuildingInfoCollect info)
        {
            if (building.currentLevel + 1 >= info.data.Length)
            {
                building.SetInteract();
                return;
            }

            if (money - info.data[building.currentLevel].cost < 0)
            {
                building.SetInteract();
            }
        }

        private void CheckUpgradeCost(Building building, BuildingInfoCollect info)
        {
            if (money - info.data[building.currentLevel].cost < 0)
            {
                if (building.currentLevel + 1 < info.data.Length)
                {
                    building.SetInteract();
                }
            }
        }

        private bool CheckFullUpgrade()
        {
            var currentBuilding = current.buildingInfo;
            return !(from building in currentBuilding
                from build in buildingDetail.buildings
                where build.buildingName == building.buildingName
                where build.currentLevel + 1 < building.data.Length
                select building).Any();
        }

        #endregion
    }
}