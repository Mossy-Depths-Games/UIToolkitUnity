using UnityEngine;
using UnityEngine.UIElements;

public class EventPropagation : MonoBehaviour
{
    VisualElement root;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        //DetermineClickWithoutEvent();
        PropagationTest();
    }

    private void DetermineClickWithoutEvent()
    {
        VisualElement blue = root.Q("Blue");
        blue.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log((evt.target as VisualElement).name + " was clicked");
            Debug.Log(evt.propagationPhase);
            ColorUtility.TryParseHtmlString("#F22F46", out Color defaultColor);
            (evt.target as VisualElement).style.backgroundColor = defaultColor;
        });
    }

    private void PropagationTest()
    {
        VisualElement blue = root.Q("Blue");
        blue.RegisterCallback<MouseDownEvent>(evt => Debug.Log("blue " + evt.propagationPhase));

        VisualElement yellow = root.Q("Yellow");
        VisualElement orange = root.Q("Orange");
        VisualElement black = root.Q("Black");

        VisualElement green = root.Q("Green");
        VisualElement red = root.Q("Red");
        VisualElement grey = root.Q("Grey");

        yellow.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("yellow " + evt.propagationPhase);
            evt.StopPropagation();
        });//, 
        //TrickleDown.TrickleDown);

        orange.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("orange " + evt.propagationPhase);
            evt.StopPropagation();
        });//,
           //TrickleDown.TrickleDown);

        black.RegisterCallback<MouseDownEvent>(evt =>
        {
            Debug.Log("black " + evt.propagationPhase);
            evt.StopPropagation();
        });//, 
        //TrickleDown.TrickleDown);

        green.RegisterCallback<MouseDownEvent>(evt => Debug.Log("green " + evt.propagationPhase), TrickleDown.TrickleDown);
        red.RegisterCallback<MouseDownEvent>(evt => Debug.Log("red " + evt.propagationPhase), TrickleDown.TrickleDown);
        grey.RegisterCallback<MouseDownEvent>(evt => Debug.Log("grey " + evt.propagationPhase), TrickleDown.TrickleDown);
    }
}
