using UnityEngine;  
using System.Collections;  
using UnityEditor;
using System.IO;
/// 
  
/// 在从外部导入texture、或者在导入之后对texture的自动处理  
///   
public class ImportResDemo : AssetPostprocessor {
    /// 
    static int count = 0;
    static int count1 = 0;
    void OnPreprocessModel()
    {
        if(assetPath.IndexOf("Models") >= 0)
        {
            ModelImporter modelImporter = assetImporter as ModelImporter;
            modelImporter.importMaterials = false;
            count++;
            if(count > 67)
            {
                AssetDatabase.Refresh();
                string[] arr = Directory.GetDirectories(Path.Combine(Application.dataPath, "FantasyCharacter3/Models"));
                for (int i = 0; i < arr.Length; i++)
                {
                    Directory.Delete(arr[i], true);

                }
            }

        }


    }

    void OnPostprocessModel(GameObject g)
    {
        if (assetPath.IndexOf("Models") >= 0)
        {
            count1++;
            if (count1 > 67)
            {
                AssetDatabase.Refresh();
                string[] arr = Directory.GetDirectories(Path.Combine(Application.dataPath, "FantasyCharacter3/Models"));
                for (int i = 0; i < arr.Length; i++)
                {
                    Directory.Delete(arr[i], true);

                }
            }
           

        }
    }
}  