using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;

public class Logger: EditorWindow
{
    [MenuItem("Tools/Logger")]
    public static Logger ShowWindow()
    {
        Logger window = GetWindow<Logger>();

        window.titleContent = new GUIContent("Logger");
        window.minSize = new Vector2(300, 300);

        return window;
    }

    private void OnEnable()
    {
        TextField message = new TextField("Message");
        ColorField color = new ColorField("Color Choosing");
        color.showAlpha = false;
        Button send = new Button(() => { Debug.Log("<color='#" + ColorUtility.ToHtmlStringRGB(color.value) +  "'>" + message.value + "</color>"); });

        send.text = "Send";

        rootVisualElement.Add(message);
        rootVisualElement.Add(color);
        rootVisualElement.Add(send);
    }
}