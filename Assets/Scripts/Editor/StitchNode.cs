using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StitchNode : NodeBaseClass
{
    public Stitch myStitch;
  public StitchNode(Rect r, int ID) : base(r, ID)
  {

  }

  public void DrawGUI(int winID)
  {
        if (GUILayout.Button("Edit"))
        {
            NE.mySWindow = SecondWindow.ShowWindow();
            NE.mySWindow.setSample(myStitch);
        }
        BaseDraw(winID);
  }

  public void AttachComplete(int winID)
  {
    base.linkedNodes.Add(winID);
  }
}