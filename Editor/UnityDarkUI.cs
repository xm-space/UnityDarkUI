#if UNITY_EDITOR_WIN // Windows only, obviously
namespace Editor.Theme // Change this to your own namespace you like or simply remove it
{
    using System.Runtime.InteropServices;
    using UnityEditor;

    public static class UnityEditorDarkMode
    {
        // Change below path to the path of the downloaded dll
        [DllImport(@"UnityEditorDarkMode.dll", EntryPoint = "DllMain")]
        private static extern void _();

        [InitializeOnLoadMethod]
        private static void __()
        {
            #if !UNITY_2021_1_OR_NEWER
            // [InitializeOnLoadMethod] is getting called before the editor
            // main window is created on earlier versions of Unity, so we
            // need to wait a bit here before attaching the dll.
            System.Threading.Thread.Sleep(100);
            #endif
            _(); // Attach the dll to the Unity Editor
        }
    }
}
#endif