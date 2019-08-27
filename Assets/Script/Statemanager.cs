using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemanager : MonoBehaviour
{
    public GameObject lavaBg;
    public GameObject goodBg;

    public ScriptableObjects scObj;

    public enum State { good, lava};
    public State state;

    public bool bossDefeated = false;

    void Start()
    {
        state = State.good;
    }

    // Update is called once per frame
    void Update()
    {
        if(bossDefeated == true)
        {
            state = State.lava;
        }
        else
        {
            state = State.good;
        }

        switch (state)
        {
            case State.good:
                lavaBg.active = false;
                goodBg.active = true;
                break;
            case State.lava:
                lavaBg.active = true;
                goodBg.active = false;
                break;
        }
    }
}
