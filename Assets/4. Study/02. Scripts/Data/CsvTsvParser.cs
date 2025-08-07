using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CsvTsvParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string charID;
        public string name;
        public int hp;
        public int damage;

        public CharacterData(string charID, string name, int hp, int damage)
        {
            this.charID = charID;
            this.name = name;
            this.hp = hp;
            this.damage = damage;
        }
    }

    public List<CharacterData> characters = new List<CharacterData>();

    void Start()
    {
        //var dataFile = Resources.Load<TextAsset>("csvData");
        var dataFile = Resources.Load<TextAsset>("tsvData");
        string data = dataFile.text;

        ParsingCharData(data);
    }

    private void ParsingCharData(string data)
    {
        Debug.Log($"Data : {data}");

        string[] rows = data.Split('\n');

        for (int i = 1; i < rows.Length; i++)
        {
            //string[] cols = rows[i].Split(',');
            string[] cols = rows[i].Split('\t');

            CharacterData charData = new CharacterData(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3]));
            
            characters.Add(charData);
        }
    }
}
