using UnityEditor;
using UnityEngine;
using System.Collections;

public class AssignMaterial : ScriptableWizard
{

    public Material material_to_apply;

    void OnWizardUpdate()
    {
        helpString = "Select Game Objects";
        isValid = (material_to_apply != null);
    }

    void OnWizardCreate()
    {
        GameObject[] gos = Selection.gameObjects;
        foreach (GameObject go in gos)
        {
            foreach (Renderer r in go.GetComponentsInChildren<Renderer>())
            {
                Material[] materials = r.sharedMaterials;
                for (int i = 0; i < materials.Length; i++)
                    materials[i] = material_to_apply;
                r.sharedMaterials = materials;

                materials = r.materials;
                for (int i = 0; i < materials.Length; i++)
                    materials[i] = material_to_apply;
                r.materials = materials;
            }
        }

    }

    [MenuItem("GameObject/Assign Material", false, 4)]
    static void CreateWindow()
    {
        ScriptableWizard.DisplayWizard("Assign Material", typeof(AssignMaterial), "Assign");
    }
}
