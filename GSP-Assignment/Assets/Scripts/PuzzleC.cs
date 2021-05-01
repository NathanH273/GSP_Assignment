using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleC : MonoBehaviour
{
    public TargetPuzzle T1;
    public TargetPuzzle T2;
    public TargetPuzzle T3;
    public TargetPuzzle T4;
    public GunV2 Reward;
    public PuzzleLoot loot;

    // Start is called before the first frame update
    void Start()
    {
        Reward = GameObject.Find("Magnum_Revolver").GetComponent<GunV2>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((T1.IsCorrect == true) && (T2.IsCorrect == true) && (T3.IsCorrect == true) && (T4.IsCorrect == true))
        {
            loot.GiveUpgrade();
            Reward.damage += 20;
            
            Destroy(this);
        }
    }
}
