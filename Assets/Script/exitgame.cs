using UnityEngine;

public class exitgame : MonoBehaviour
{
    public void Exit()
    {
        // Exit the application
        Application.Quit();

        // If running in the Unity editor, log a message
#if UNITY_EDITOR
        Debug.Log("Application.Quit() called. This will only work in a build.");
#endif
    }
}
