using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DropdownController
{
    VisualElement root;
    Faction currentFaction;

    public DropdownController(VisualElement root, List<Faction> factions)
    {
        this.root = root;
        //DropdownField dropdownOld = new DropdownField();
        VisualElement dropdownContainer = root.Q("DropdownContainer");
        //A Popupfield is just like a DropdownField but a PopupField lets the choices be an object
        //The DropdownField restricts the choices to just a string.
        //So we can set the choices to a List of Faction, where a DropDownField coud just be a list of string.
        PopupField<Faction> dropDownNew = new PopupField<Faction>();
        dropDownNew.choices = factions;
        dropDownNew.value = factions[0];

        dropDownNew.formatListItemCallback = elem => elem.factionName;
        dropDownNew.formatSelectedValueCallback = elem => elem.factionName;

        dropDownNew.RegisterCallback<ChangeEvent<Faction>>(OnFactionSelected);

        dropdownContainer.Add(dropDownNew);
        currentFaction = factions[0];
        UpdateUI();
    }

    private void OnFactionSelected(ChangeEvent<Faction> evt)
    {
        currentFaction = evt.newValue;
        UpdateUI();
    }

    void UpdateUI()
    {
        VisualElement characterElem = root.Q<VisualElement>("Character");
        Sprite charImg = Resources.Load<Sprite>(currentFaction.characterImgPath);
        characterElem.style.backgroundImage = new StyleBackground(charImg);

        Label factionLabel = root.Q<Label>("FactionName");
        factionLabel.text = currentFaction.factionName;

        Label mottoLabel = root.Q<Label>("FactionMotto");
        mottoLabel.text = currentFaction.factionMoto;

        VisualElement factionImgElem = root.Q<VisualElement>("PanelFaction");
        Sprite factionImg = Resources.Load<Sprite>(currentFaction.factionImgPath);
        factionImgElem.style.backgroundImage = new StyleBackground(factionImg);
    }
}
