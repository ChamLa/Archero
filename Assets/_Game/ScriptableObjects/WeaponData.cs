using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponData : ScriptableObject
{
    [SerializeField] List<WeaponItem> weaponItems;

    public List<WeaponItem> WeaponItems => weaponItems;

    public WeaponItem GetWeaponItem(WeaponType weaponType)
    {
        //return weaponItems.Single(q => q.type == weaponType);
        return weaponItems[(int)weaponType];
    }

}

[System.Serializable]
public class WeaponItem
{
    public string name;
    public WeaponType type;
    public Weapon weapon;
    public int cost;
    public int ads;
}
