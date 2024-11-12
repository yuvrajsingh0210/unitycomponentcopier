using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

public class ComponentCopier : EditorWindow
{
    private GameObject sourcePrefab;
    private GameObject targetPrefab;
    private bool pickFromScene = false;
    private bool showDebug = true;
    
    [MenuItem("Tools/Component Copier")]
    public static void ShowWindow()
    {
        GetWindow<ComponentCopier>("Component Copier");
    }
    
    void OnGUI()
    {
        pickFromScene = EditorGUILayout.Toggle("Pick From Scene", pickFromScene);
        showDebug = EditorGUILayout.Toggle("Show Debug Info", showDebug);
        
        sourcePrefab = (GameObject)EditorGUILayout.ObjectField("Source Object", sourcePrefab, typeof(GameObject), pickFromScene);
        targetPrefab = (GameObject)EditorGUILayout.ObjectField("Target Object", targetPrefab, typeof(GameObject), pickFromScene);
        
        if(GUILayout.Button("Copy Components"))
        {
            if(sourcePrefab != null && targetPrefab != null)
            {
                CopyComponents();
            }
        }
    }
    
    void CopyComponents()
    {
        // Get all source objects and their components
        var sourceObjects = sourcePrefab.GetComponentsInChildren<Transform>();
        int copied = 0;

        // Create dictionary of target objects by name for faster lookup
        Dictionary<string, Transform> targetObjects = new Dictionary<string, Transform>();
        foreach(Transform t in targetPrefab.GetComponentsInChildren<Transform>())
        {
            if(!targetObjects.ContainsKey(t.name))
            {
                targetObjects.Add(t.name, t);
            }
        }
        
        // Copy components
        foreach(var sourceTransform in sourceObjects)
        {
            if(targetObjects.TryGetValue(sourceTransform.name, out Transform targetTransform))
            {
                var components = sourceTransform.GetComponents<Component>();
                foreach(var comp in components)
                {
                    if(comp == null || comp is Transform) continue;
                    
                    try
                    {
                        Component newComponent = targetTransform.gameObject.AddComponent(comp.GetType());
                        EditorUtility.CopySerialized(comp, newComponent);
                        copied++;
                        
                        if(showDebug)
                        {
                            Debug.Log($"Copied {comp.GetType().Name} from {sourceTransform.name} to {targetTransform.name}");
                        }
                    }
                    catch(System.Exception e)
                    {
                        Debug.LogWarning($"Failed to copy component {comp.GetType().Name} from {sourceTransform.name}: {e.Message}");
                    }
                }
            }
            else if(showDebug)
            {
                Debug.LogWarning($"No matching object found for: {sourceTransform.name}");
            }
        }
        
        Debug.Log($"Copied {copied} components");
        
        if(!pickFromScene)
        {
            PrefabUtility.SavePrefabAsset(targetPrefab);
        }
    }
}