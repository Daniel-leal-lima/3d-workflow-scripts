using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class PivotCentralizer : ScriptableObject
{

    [MenuItem("GameObject/Tooling/Custom Empty Object with pivot Centralizer", false, priority = 0)]
    static void CreateCustomGameObject(MenuCommand menuCommand)
    {
        if(menuCommand.context != null) // has an gameObject slected in hierarchy menu
        {
            GameObject selObj = (GameObject) menuCommand.context;
            
            if(selObj.TryGetComponent(out Renderer rend))
            {
                // Centralize GameObject
                GameObject obj = new GameObject(string.Join(" ", selObj.name, "pivot"));
                obj.transform.position = rend.bounds.center;
                obj.transform.rotation = selObj.transform.rotation;

                // SetParent
                GameObjectUtility.SetParentAndAlign(selObj, obj as GameObject);
                Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
                Selection.activeObject = obj;
            }
            else
            {
                Debug.LogWarning("GameObject has no Renderer Attached! Centralizing per First Transform");
                // Centralize GameObject
                GameObject obj = new GameObject(string.Join(" ", selObj.name, "pivot"));
                obj.transform.position = selObj.GetComponentInChildren<Transform>().GetChild(0).position;
                obj.transform.rotation = selObj.GetComponentInChildren<Transform>().GetChild(0).rotation;

                // SetParent
                selObj.transform.SetParent(obj.transform);
                Undo.RegisterCreatedObjectUndo(obj, "Create " + obj.name);
                Selection.activeObject = obj;
            }
        }
        
    }
}

