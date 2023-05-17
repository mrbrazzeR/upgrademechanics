using System;
using UnityEngine;
using UnityEngine.UI;

namespace UpgradeMechanics
{
    public class Building:MonoBehaviour
    {
        public string buildingName;
        public int currentLevel;
        public SpriteRenderer buildingImage;
        public Button upgradeButton;

        public delegate void Upgrade(Building building);

        public event Upgrade OnPublish;

        private void Awake()
        {
            upgradeButton.onClick.AddListener(Publish);
        }

        public void SetSprite(Sprite sprite)
        {
            buildingImage.sprite = sprite;
        }

        public void SetInteract()
        {
            upgradeButton.interactable = false;
        }
        public void Publish()
        {
            OnPublish?.Invoke(this);
        }
    }
}