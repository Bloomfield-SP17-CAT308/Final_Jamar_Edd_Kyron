using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GControl : MonoBehaviour {

    public static GameLevel level;
	
    void OnAwake()
    {
        level = GameLevel.L1;
    }

}
