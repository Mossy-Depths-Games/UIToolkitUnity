using UnityEngine;
using UnityEngine.UIElements;

namespace Testing_VE
{
    public class TestingVisualElements : MonoBehaviour
    {
        VisualElement container;
        VisualElement item;

        private void OnEnable()
        {
            VisualElement root = GetComponent<UIDocument>().rootVisualElement;
            container = root.Q("Container");

            item = new VisualElement();
            item.style.width = 100;
            item.style.height = 100;
            item.style.backgroundColor = Color.white;
            container.Add(item);

        }
    }
}