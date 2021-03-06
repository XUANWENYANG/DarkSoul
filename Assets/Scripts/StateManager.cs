﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : IActorManagerInterface {

    public float HPMax = 25.0f;
    public float HP = 15.0f;
    public float ATK = 10.0f;

    [Header("1st order state flag")]
    public bool isGround;
    public bool isJump;
    public bool isFall;
    public bool isRoll;
    public bool isJab;
    public bool isAttack;
    public bool isHit;
    public bool isDie;
    public bool isBlock;
    public bool isDefense;
    public bool isCounterBack; // related to state
    public bool isCounterBackEnable; // related to animation event

    [Header("2nd order state flag")]
    public bool isAllowDefense;
    public bool isImmortal;
    public bool isCounterBackSucess;
    public bool isCounterBackFailure;

    void Start() {
        HP = HPMax;
    }

    void Update() {
        isGround = am.ac.CheckState("ground");
        isJump = am.ac.CheckState("jump");
        isRoll = am.ac.CheckState("roll");
        isJab = am.ac.CheckState("jab");
        isFall = am.ac.CheckState("fall");
        isHit = am.ac.CheckState("hit");
        isDie = am.ac.CheckState("die");
        isBlock = am.ac.CheckState("block");
        //isDefense = am.ac.CheckState("defense", "defense");
        isAttack = am.ac.CheckStateTag("attackR") || am.ac.CheckStateTag("attackL");
        isCounterBack = am.ac.CheckState("counterBack");

        isAllowDefense = isGround || isBlock;

        isDefense = isAllowDefense && am.ac.CheckState("defense", "defense");
        isImmortal = isRoll || isJab;
        isCounterBackSucess = isCounterBackEnable;
        //print(isCounterBackEnable);
        isCounterBackFailure = isCounterBack && !isCounterBackEnable;
    } 

    public void AddHP(float value) {
        HP += value;
        HP = Mathf.Clamp(HP, 0, HPMax);
    }

}
