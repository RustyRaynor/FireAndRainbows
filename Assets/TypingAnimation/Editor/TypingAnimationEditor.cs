using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(TypingAnimation))]
[CanEditMultipleObjects]
public class TypingAnimationEditor : Editor
{
    readonly string[] cursorOptions = { "None", "|", "❘", "❙", "❚", "▮", "▯", "⌶",
    "▉", "▊", "▋", "▌", "▍", "▎", "▏"};
    public int cursorIndex = 0;

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        DrawDefaultInspector();
        TypingAnimation typingAnimation = serializedObject.targetObject as TypingAnimation;

        EditorGUI.BeginChangeCheck();
        cursorIndex = EditorGUILayout.Popup(cursorIndex, cursorOptions);
        if (EditorGUI.EndChangeCheck())
        {
            if (cursorIndex == 0)
                typingAnimation.SetCursor(' ');
            else
                typingAnimation.SetCursor(cursorOptions[cursorIndex][0]);
        }

        if (GUILayout.Button("Test"))
            typingAnimation.TypeString(typingAnimation.initialString);

        if (GUILayout.Button("Blink"))
            typingAnimation.StartBlinking();

        if (GUILayout.Button("Stop Blinking"))
            typingAnimation.StopBlinking();

        if (GUILayout.Button("Delete All"))
            typingAnimation.DeleteAll();

        serializedObject.ApplyModifiedProperties();
    }
}
