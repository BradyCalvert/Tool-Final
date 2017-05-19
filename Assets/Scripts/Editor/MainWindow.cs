using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MainWindow : EditorWindow
{
  public Stitch mySample;
  public Stitch mySample2;
  public SecondWindow mySWindow;
  [MenuItem("Window/NodeWindow")]
  public static void ShowWindow()
  {
    GetWindow<MainWindow>();
  }
  void OnGUI()
  {
    mySample = (Stitch)EditorGUILayout.ObjectField(mySample, typeof(Stitch), true);
    if (mySample != null)
    {
            if (GUILayout.Button("Edit"))
            {
                mySWindow = SecondWindow.ShowWindow();
               mySWindow.setSample(mySample);
            }
        }
  }
}