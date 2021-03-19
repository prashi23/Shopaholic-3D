using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item {

    public enum ItemType {
        Milk,
        Cereal,
        IceCream,
        HotDog,
        Tomoto,
        Corn,
        ScrewDriver,
        Wrench,
        Computer,
        TV,
        Console,
        Books,
        Drink
    }

    public ItemType itemType;
    public int amount;


    public Sprite GetSprite() {
        switch(itemType) {
            default:
            case ItemType.Cereal: return ItemAssets.Instance.CerealSprite;
            case ItemType.Milk: return ItemAssets.Instance.MilkSprite;
            case ItemType.IceCream: return ItemAssets.Instance.IceCreamSprite;
            case ItemType.HotDog: return ItemAssets.Instance.HotdogSprite;
            case ItemType.Tomoto: return ItemAssets.Instance.TomotoSprite;
            case ItemType.Corn: return ItemAssets.Instance.CornSprite;
            case ItemType.Wrench: return ItemAssets.Instance.WrenchSprite;
            case ItemType.ScrewDriver: return ItemAssets.Instance.ScrewDriverSprite;
            case ItemType.Computer: return ItemAssets.Instance.ComputerSprite;
            case ItemType.Console: return ItemAssets.Instance.ConsoleSprite;
            case ItemType.Drink: return ItemAssets.Instance.DrinkSprite;
            case ItemType.TV: return ItemAssets.Instance.TvSprite;
        }
    }


}
