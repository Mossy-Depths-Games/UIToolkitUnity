using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class EventExample : MonoBehaviour
{
    VisualElement root;
    VisualElement element;

    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        Slider slider = root.Q<Slider>("MySlider");
        TextField textField = root.Q<TextField>("MyTextField");
        element = root.Q("MyElem");

        
        slider.RegisterCallback<ChangeEvent<float>>(evt => Debug.Log((evt.target as VisualElement).name + " Slider ChangeEvent"));
    
        textField.RegisterCallback<InputEvent>(evt => Debug.Log((evt.target as VisualElement).name + " TextField InputEvent"));
        textField.RegisterCallback<FocusEvent>(evt => Debug.Log((evt.target as VisualElement).name + " TextField FocusEvent"));

        element.RegisterCallback<PointerEnterEvent>(evt => Debug.Log((evt.target as VisualElement).name + " element PointerEnterEvent"));
        element.RegisterCallback<GeometryChangedEvent>(evt => Debug.Log((evt.target as VisualElement).name + " element GeometryChangedEvent"));
    }
    private void OnSliderValueChanged(ChangeEvent<float> changeEvent)
    {
        Debug.Log(changeEvent.newValue);
        Debug.Log(changeEvent.previousValue);
    }
    private void OnPointerEnter(PointerEnterEvent pointerEnterEvent)
    {
        Debug.Log(pointerEnterEvent.position);
        Debug.Log(pointerEnterEvent.pressure);  //amount of pressure from a stylus, neat
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            element.style.width = 500;
        }
    }
}
