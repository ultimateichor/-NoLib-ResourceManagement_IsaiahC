// IneffientLoader.cs - DON'T use this in production!

using UnityEngine; 
public class InefficientLoader : MonoBehaviour 
{ 
    void Start() 
    { 
        // Load same texture multiple times - WASTEFUL!
        for (int i = 0; i < 10; i++) 
        { 
            Texture2D texture = Resources.Load<Texture2D>("ground_texture"); Debug.Log($"Loaded texture {i}: {texture.width}x{texture.height}"); } // Check memory usage
            long memoryUsed = System.GC.GetTotalMemory(false); Debug.Log($"Memory used: {memoryUsed / 1024 / 1024} MB"); } } 