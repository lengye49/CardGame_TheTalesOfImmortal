﻿using System.Collections;
using System.Collections.Generic;

public class Player{
    public int Hp = 1;
    public int HpMax = 1;
    public int Mp = 1;
    public int Card = 3;

    public int Shield;
    public int Armor = 0;
    public int PhysicalReduction = 0;
    public int MagicalReduction = 0;
    public int HealPerRound;
    public int Poison = 0;
    public int Sunder = 0;
    public int Weak = 0;
    public int Acceleration = 0;
    public int Deceleration = 0;
    public int Rebound = 0;
    public int Dodge = 0;
    public bool DamageToMana = false;

	public Dictionary<CardBuffType,int> PlayerBuff;//id,层数&效果
    public List<CardBuff> PlayerBuffs;
	public List<CardData> Library;
	public List<CardData> Hands;
	public List<CardData> Graveyard;
    public List<Puppet> Puppets;

	public Player(int hp,int hpMax,int initMana,List<CardData> library){
        Hp = hp;
        HpMax = hpMax;
        Mp = initMana;
        PlayerBuffs = new List<CardBuff>();
        Library = library;
        Hands = new List<CardData>();
        Graveyard = new List<CardData>();
        Puppets = new List<Puppet>();
    }

	public void EndRound(){
		//抽卡
		if (Hands.Count < Card) {
			DrawCards (Card - Hands.Count);
		}

	}

	public void StartRound(){
		//结算buff效果
		if (HealPerRound > 0)
			Hp += HealPerRound;
		if (Poison > 0) {
			Hp -= Poison;
		}

		//结算Duration
		for(int i=0;i<PlayerBuffs.Count;i++){
			PlayerBuffs [i].Duration--;
			if (PlayerBuffs [i].Duration<=0) {

				//清楚效果
				PlayerBuffs.RemoveAt (i);
			}
		}
	}


	public void DrawCards(int count){
		for (int i = 0; i < count; i++) {
			if (Library.Count <= 0) {
				if (Graveyard.Count > 0)
					Shuffle ();
				else {
					return;
				}
			}
			int index = MathCalculation.GetRandomValue (Library.Count);
			Hands.Add (Library [index]);
			Library.RemoveAt (index);
		}
	}

	public void RemoveHand(){
		if (Hands.Count <= 0)
			return;
		int index = MathCalculation.GetRandomValue (Hands.Count);
		RemoveHand (index);
	}

	public void RemoveHand(int index){
		if (Hands.Count <= index)
			return;
		Hands.RemoveAt (index);
	}

	void Shuffle(){
		for (int i = 0; i < Graveyard.Count; i++) {
			Library.Add (Graveyard [i]);
		}
		Graveyard.Clear ();
	}
}


