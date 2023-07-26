using UnityEngine;
using UnityEngine.UIElements;

public class EventPropagation : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        VisualElement blue = root.Q("Blue");
        VisualElement yellow = root.Q("Yellow");
        VisualElement orange = root.Q("Orange");
        VisualElement black = root.Q("Black");

        VisualElement green = root.Q("Green");
        VisualElement red = root.Q("Red");
        VisualElement grey = root.Q("Grey");

        blue.RegisterCallback<MouseDownEvent>(evt => Debug.Log("blue " + evt.propagationPhase));

        yellow.RegisterCallback<MouseDownEvent>(evt => Debug.Log("yellow " + evt.propagationPhase), TrickleDown.TrickleDown);
        orange.RegisterCallback<MouseDownEvent>(evt => Debug.Log("orange " + evt.propagationPhase), TrickleDown.TrickleDown);
        black.RegisterCallback<MouseDownEvent>(evt => Debug.Log("black " + evt.propagationPhase), TrickleDown.TrickleDown);

        green.RegisterCallback<MouseDownEvent>(evt => Debug.Log("green " + evt.propagationPhase), TrickleDown.TrickleDown);
        red.RegisterCallback<MouseDownEvent>(evt => Debug.Log("red " + evt.propagationPhase), TrickleDown.TrickleDown);
        grey.RegisterCallback<MouseDownEvent>(evt => Debug.Log("grey " + evt.propagationPhase), TrickleDown.TrickleDown);
    }
}
