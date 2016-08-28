﻿using UnityEngine;
using System.Collections.Generic;

public class Drawing : MonoBehaviour {
    public GameObject pen, desk;
    public Material mat;
    public List<Vector3> nodeList = new List<Vector3>();
    private Vector3 penPos;
    private LineRenderer line;
    private bool lineDraw, penDown = false;

    void Update() {
        Debug.Log(Physics.Raycast(pen.transform.position, Vector3.down));
        //Raise pen
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            penDown = false;
            lineDraw = false;
        }
        // Nothing to draw on
        if (!Physics.Raycast(pen.transform.position, Vector3.down))
        {
            lineDraw = false;
        }
        // Start drawing new line; need something
        else if (/*(Input.GetKeyDown(KeyCode.Mouse0) ||*/ penDown && Physics.Raycast(pen.transform.position, Vector3.down))
        {
            if (!lineDraw) {
                GameObject myLine = new GameObject();
                myLine.transform.position = pen.transform.position;
                myLine.AddComponent<LineRenderer>();
                line = myLine.GetComponent<LineRenderer>();
                line.material = mat;
                line.receiveShadows = true;
                //line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                line.SetVertexCount(1);
                line.SetColors(Color.black, Color.black);
                line.SetWidth(0.002f, 0.002f);
                line.useWorldSpace = true;
                nodeList = new List<Vector3>();
                line.SetPosition(0, transform.localPosition);
                //penDown = true;
                lineDraw = true;
            }
            else {
                nodeList.Add(pen.transform.position);
                line.SetVertexCount(nodeList.Count);
                line.SetPosition(nodeList.Count - 1, (Vector3)nodeList[nodeList.Count - 1]);
            }
        }
        // Continue drawing as long as something to draw on
        //if (lineDraw && penDown && Physics.Raycast(pen.transform.position, Vector3.down)) {
        //    nodeList.Add(pen.transform.position);
        //    line.SetVertexCount(nodeList.Count);
        //    line.SetPosition(nodeList.Count - 1, (Vector3)nodeList[nodeList.Count - 1]);
        //}
        // Lower pen
        if ((Input.GetKeyDown(KeyCode.Mouse0)))
        {
            penDown = true;
        }
    }
}
