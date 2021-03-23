using UnityEngine;
using UnityEngine.UI;

// UI.Text.text example
//
// A Space keypress changes the message shown on the screen.
// Two messages are used.
//
// Inside Awake a Canvas and Text are created.

public class WheelRPM : MonoBehaviour
{
    private enum UpDown { Down = -1, Start = 0, Up = 1 };
    private Text text;
    private UpDown textChanged = UpDown.Start;
    public Vector3 labelPos;
    public string WheelName;
    public WheelCollider WheelCollider;
    void Awake()
    {
        // Load the Arial font from the Unity Resources folder.
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        // Create Canvas GameObject.
        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Get canvas from the GameObject.
        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Create the Text GameObject.
        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        // Set Text component properties.
        text = textGO.GetComponent<Text>();
        text.font = arial;
        // text.text = "Press space key";
        text.fontSize = 14;
        text.alignment = TextAnchor.MiddleCenter;

        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = text.GetComponent<RectTransform>();
        rectTransform.localPosition = labelPos;
        rectTransform.sizeDelta = new Vector2(600, 200);
    }

    void Update()
    {
        // Press the space key to change the Text message.
        
        text.text = WheelName +" RPM :"+ (int)WheelCollider.rpm;
      
    }
}