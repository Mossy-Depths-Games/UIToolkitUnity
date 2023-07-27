using System.Collections.Generic;
using UnityEngine;

public class DataSimulator : MonoBehaviour
{
    public static List<CharacterModel> GetData()
    {
        List<CharacterModel> dummyData = new List<CharacterModel>();
        CharacterModel charGuts = new CharacterModel("Guts", "Hero", "Guts");
        CharacterModel charCaska = new CharacterModel("Caska", "Hero", "Caska");
        CharacterModel charGriffith = new CharacterModel("Griffith", "Villain", "Griffith");

        dummyData.Add(charGuts);
        dummyData.Add(charCaska);
        dummyData.Add(charGriffith);

        return dummyData;
    }
}
