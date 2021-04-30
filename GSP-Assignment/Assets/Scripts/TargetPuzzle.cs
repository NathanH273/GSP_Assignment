using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPuzzle : MonoBehaviour
{
    public GameObject target;
    int CPos;
    int TPos = 0;
    float distance;
    public bool IsCorrect;
    // Start is called before the first frame update
    void Start()
    {
        CPos = Random.Range(0, 3);
        Debug.Log("CPOS: " + CPos);
    }

    // Update is called once per frame
    void Update()
    {
        if(TPos == CPos)
        {
            target.GetComponent<MeshRenderer>().material.color = Color.green;
            IsCorrect = true;
        }
        else
        {
            target.GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }

    public void hitT()
    {
        if (TPos < 4)
        {
            transform.Translate(0,-1,0, Space.Self);
            TPos += 1;
        }
        if (TPos == 3 )
        {
            transform.Translate(0, 3, 0, Space.Self) ;
            TPos = 0;
        }

    }
    
}
