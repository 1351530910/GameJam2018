using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main {

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void setup(){
        ViewController.Init();
    }
}
