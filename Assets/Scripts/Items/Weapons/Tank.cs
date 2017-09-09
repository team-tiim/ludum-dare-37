﻿using Assets.Scripts;
using Assets.Scripts.Weapons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : ProjectileWeapon
{

    public Tank()
    {
        damage = 100;
        idleAnimation = "weapon_tank_idle";
        gravityScale = 0.1f;
        attackCooldown = 1;
    }
}