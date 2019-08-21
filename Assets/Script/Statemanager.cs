using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemanager : MonoBehaviour
{
    public GameObject lavaBg;
    public GameObject goodBg;
    // Start is called before the first frame update
    enum State { good, lava};
    State state;
    void Start()
    {
        state = State.good;
    }

    // Update is called once per frame
    void Update()
    {
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
