using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemanager : MonoBehaviour
{
    public GameObject lavaBg;
    public GameObject goodBg;

    GameManager manager;

    public ScriptableObjects scObj;

    public enum State { good, mid, lava};
    public State state;

    public int bossDefeated = 0;

    void Start()
    {
        state = State.good;
        manager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bossDefeated == 1)
        {
            state = State.mid;
        }
        else if(bossDefeated >= 2)
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
            case State.mid:
                lavaBg.active = true;
                goodBg.active = false;
                manager.playerUni.GetComponentInChildren<ShaderChange>().Mid();
                break;
            case State.lava:
                lavaBg.active = true;
                goodBg.active = false;
                manager.playerUni.GetComponentInChildren<ShaderChange>().Lava();
                break;
        }
    }
}
