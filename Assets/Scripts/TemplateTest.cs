using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class TemplateTest : MonoBehaviour
{
    VisualElement cardContainer;

    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        cardContainer = root.Q("CardContainer");
        VisualTreeAsset cardTemplate = Resources.Load<VisualTreeAsset>("Card");

        VisualElement guts = cardTemplate.Instantiate();
        guts.Q<Label>("NameLabel").text = "Guts";
        cardContainer.Add(guts);

        VisualElement caska = cardTemplate.Instantiate();
        caska.Q<Label>("NameLabel").text = "Caska";
        cardContainer.Add(caska);

        Sprite gutsImage = Resources.Load<Sprite>("Guts");
        guts.Q<VisualElement>("Avatar").style.backgroundImage = new StyleBackground(gutsImage);

        Sprite caskaImage = Resources.Load<Sprite>("Caska");
        caska.Q<VisualElement>("Avatar").style.backgroundImage = new StyleBackground(caskaImage);

        //loading style sheets
        StyleSheet borderStyle = Resources.Load<StyleSheet>("StyleSheets/StyleSheet_Border");
        root.styleSheets.Add(borderStyle);

        //VisualElement actualCard = caska.Children().First();
        VisualElement actualCard = caska.Q<VisualElement>("CardFrame");
        actualCard.AddToClassList("grey_border");
    }
}
