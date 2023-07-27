using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DataBindingExample : MonoBehaviour
{
    List<CharacterModel> characterModels;
    List<VisualElement> cards = new List<VisualElement>();
    List<CardViewModel> cardsViewModels = new List<CardViewModel>();
    TextField nameField;
    TextField descriptionField;
    CharacterModel curCharacterModel;
    VisualElement cardContainer;

    private void OnEnable()
    {
        characterModels = DataSimulator.GetData();
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        cards = root.Query(className: "card").ToList();
        for(int i=0; i<characterModels.Count && i< cards.Count; ++i)
            cardsViewModels.Add(new CardViewModel(cards[i], characterModels[i]));

        nameField = root.Q<TextField>("NameField");
        descriptionField = root.Q<TextField>("DescriptionField");

        nameField.RegisterCallback<ChangeEvent<string>>(OnNameChanged);
        descriptionField.RegisterCallback<ChangeEvent<string>>(OnDescriptionChanged);

        cardContainer = root.Q("CardContainer");
        cardContainer.RegisterCallback<ClickEvent>(OnCardSelected);

        AddCard();
    }
    private void OnCardSelected(ClickEvent evt)
    {
        VisualElement element = evt.target as VisualElement;
        if (element != null)
        {
            CharacterModel characterModel = element.userData as CharacterModel;
            if (characterModel != null)
            {
                curCharacterModel = characterModel;
                //Avoid the change event with SetValueWithoutNotify instead of setting the value
                nameField.SetValueWithoutNotify(curCharacterModel.Name);
                descriptionField.SetValueWithoutNotify(curCharacterModel.Description);
            }
        }
    }
    private void OnNameChanged(ChangeEvent<string> e)
    {
        if (curCharacterModel != null)
            curCharacterModel.Name = e.newValue;
    }
    private void OnDescriptionChanged(ChangeEvent<string> e)
    {
        if (curCharacterModel != null)
        {
            curCharacterModel.Description = e.newValue;
        }
    }
    
    //Example to dynamically add a card
    private void AddCard()
    {
        string name = "Guts";
        string description = "Killer";

        VisualTreeAsset cardTemplate = Resources.Load<VisualTreeAsset>("Card");
        VisualElement cardElem = cardTemplate.Instantiate();
        cards.Add(cardElem);
        cardContainer.Add(cardElem);
        CharacterModel characterModel = new CharacterModel(name, description, name);
        characterModels.Add(characterModel);

        cardsViewModels.Add(new CardViewModel(cardElem, characterModel));
    }
}
