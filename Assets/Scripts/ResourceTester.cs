// ResourceTester.cs
using UnityEngine;

public class ResourceTester : MonoBehaviour
{
    public string[] texturePaths = {
    "256texture",
    "512texture",
    "1024texture",
    "2048texture"
    };
    
    void Start()
    {
        Debug.Log("Starting Resource Manager Test...");
        Invoke("RunTest", 1f);
    }
    
    void RunTest()
    {
        // Load each texture 3 times
        for (int i = 0; i < 3; i++)
        {
        Debug.Log($"\n--- Load Pass {i + 1} ---");
        foreach (string path in texturePaths)
        {
        Texture2D tex = ResourceManager.Instance.LoadTexture(path);
        }
        }
        // Print statistics
        Debug.Log("\n");
        ResourceManager.Instance.PrintStats();
        // Expected result:
        // - 4 textures loaded (first pass)
        // - 8 cache hits (second and third passes)
    }

    void Update()
    {
        // Press U to unload a specific texture
        if (Input.GetKeyDown(KeyCode.U))
        {
            ResourceManager.Instance.UnloadTexture(texturePaths[0]);
            ResourceManager.Instance.PrintStats();
        }
        
        // Press C to clear all cache
        if (Input.GetKeyDown(KeyCode.C))
        {
            ResourceManager.Instance.ClearCache();
            ResourceManager.Instance.PrintStats();
        }
    }
}