using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour {

    public static ItemAssets Instance { get; private set; }

    public Sprite CerealSprite;
    public Sprite MilkSprite;
    public Sprite IceCreamSprite;
    public Sprite HotdogSprite;
    public Sprite CornSprite;
    public Sprite TomotoSprite;
    public Sprite ScrewDriverSprite;
    public Sprite WrenchSprite;
    public Sprite ClothSprite;
    public Sprite ComputerSprite;
    public Sprite ConsoleSprite;
    public Sprite TvSprite;
    public Sprite DrinkSprite;


    void Awake() {
        Instance = this;

    }

    
}
