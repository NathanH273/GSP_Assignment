using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPuzzle : MonoBehaviour
{
    public GameObject target2;
    public GameObject target;
    int TPos = 0;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        Color WrongColour = new Color(256, 0, 0, 1);
        Color RightColour = new Color(0, 256, 0, 1);

        MeshRenderer targetRenderer = target.GetComponent<MeshRenderer>();
        Material newMaterial = new Material(Shader.Find("Correct"));

        newMaterial.color = WrongColour;
        targetRenderer.material = newMaterial;

        distance = Vector3.Distance(target.transform.postition, target2.transform.position);
        Debug.Log("Dis:" + distance);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void hitT()
    {
        Debug.Log("I");
        if (TPos < 3)
        {
            Debug.Log(TPos);
            transform.Translate(0,-1,0, Space.Self);
            TPos += 1;
        }
        if (TPos == 3 )
        {
            Debug.Log(TPos);
            transform.Translate(0, 3, 0, Space.Self) ;
            TPos = 0;
        }

    }
}
