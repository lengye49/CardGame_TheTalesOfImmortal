﻿using System.Collections.Generic;

public class Hero {
    
    public int Hp;
    public int HpMax;
    public int Mp;
    public int MpMax;
    public int Action;
    public int ActionMax;

    public List<Skill> Skills;
    public List<DungeonAbility> DugeonAbilities;

    public int Profession;
    public int Lv;
    public int Gold;
    public int HandSize;
    public int[] DungeonState;
    public List<Card> Cards;
    public int[] EquipPositions;

}