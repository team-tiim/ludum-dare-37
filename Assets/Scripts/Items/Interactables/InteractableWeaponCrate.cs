﻿using UnityEngine;

public class InteractableWeaponCrate : BaseInteractable {

    public GameObject[] weaponPrefabs;

    void Awake()
    {
        foreach (GameObject wp in weaponPrefabs)
        {
            if (wp.GetComponent<Weapon>() == null)
            {
                throw new System.Exception("Interactable weapon crate"  + this.name + " does not have valid weapon prefab: " + wp.name);
            }
        }
    }

    protected override void OnPlayerPickup(Collider2D player)
    {
        player.gameObject.AddComponent<TimedWeaponBehaviour>().duration = spawner.spawnTick;
        GameObject go = RandomUtils.GetRandomFromArray(weaponPrefabs);
        player.GetComponent<WeaponController>().EquipWeapon(go);
    }
}
