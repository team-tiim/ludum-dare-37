﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Weapons
{
    class Knife : Weapon
    {
        public Knife()
        {
            _damage = 5;
            _idleAnimation = "weapons1_0";
        }
    }
}
