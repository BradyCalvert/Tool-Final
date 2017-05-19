using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Reflection;

public class ReflectionWindow : EditorWindow
{
  public GameObject go;
  public Component co;

  public List<Component> comList = new List<Component>();
  public List<string> comNames = new List<string>();

  public List<MethodInfo> methList = new List<MethodInfo>();
  public List<string> methNames = new List<string>();
  public int comSelected = 0;
  public int methSelected = 0;
  public static void ShowWindow()
  {
    GetWindow<ReflectionWindow>();


  }
  void OnGUI()
  {
    EditorGUI.BeginChangeCheck();
    go = (GameObject)EditorGUILayout.ObjectField(go, typeof(GameObject), true);
    if (EditorGUI.EndChangeCheck())
    {
      if (go != null)
      {
        comList.Clear();
        comNames.Clear();
        comList = new List<Component>(go.GetComponents(typeof(Component)));
        foreach (Component c in comList)
        {
          comNames.Add(c.GetType().Name);
        }
      }
      else
      {
        comList.Clear();
        comNames.Clear();
      }
    }
    if (comNames.Count > 1)
    {
      EditorGUI.BeginChangeCheck();
      comSelected = EditorGUILayout.Popup(comSelected, comNames.ToArray());
      if (EditorGUI.EndChangeCheck())
      {
        methNames.Clear();
        methList.Clear();
        co = comList[comSelected];
        BindingFlags flag = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance; ;
        methList = new List<MethodInfo>(co.GetType().GetMethods(flag));
        foreach (MethodInfo a in methList)
        {
          methNames.Add(a.Name);

        }
      }
      if (methList.Count > 1)
      {
        methSelected = EditorGUILayout.Popup(methSelected, methNames.ToArray());
        if (GUILayout.Button("Run"))
        {
          methList[methSelected].Invoke(co, null);
        }
      }
    }
  }


}