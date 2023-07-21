using UnityEngine;
using UnityEngine.UIElements;


public class Button_Screen : MonoBehaviour
{
    VisualElement box;
    Button myButton;

    private void OnEnable()
    {
        UIDocument ui = GetComponent<UIDocument>();
        VisualElement root = ui.rootVisualElement;
        box = root.Q("Box");    //Q means Query
        myButton = root.Q<Button>("MyButton");
        myButton.clicked += MyButton_clicked;
    }

    private void MyButton_clicked()
    {
        int randomWidth = Random.Range(50, 300);
        box.style.width = randomWidth;
    }
}
