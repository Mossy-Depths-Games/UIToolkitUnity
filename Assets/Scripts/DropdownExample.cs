using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DropdownExample : MonoBehaviour
{
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        DropdownField dropdown = root.Q<DropdownField>("MyDropDown");

        List<string> data = new List<string>{"a", "b", "c", "d"};
        dropdown.choices = data;
        dropdown.value = data[0];

        dropdown.formatSelectedValueCallback = elem => "Hello " + elem;
        dropdown.formatListItemCallback = elem => "I am " + elem;
        dropdown.RegisterCallback<ChangeEvent<string>>(OnSelectionChanged);
    }

    private void OnSelectionChanged(ChangeEvent<string> evt)
    {
        Debug.Log(evt.newValue);   
    }
}