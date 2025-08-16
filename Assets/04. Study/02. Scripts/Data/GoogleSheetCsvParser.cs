using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GoogleSheetCsvParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string charID;
        public string name;
        public int hp;
        public int attack;

        public CharacterData(string charID, string name, int hp, int attack)
        {
            this.charID = charID;
            this.name = name;
            this.hp = hp;
            this.attack = attack;
        }
    }

    public string URL;
    public List<CharacterData> characters = new List<CharacterData>();

    IEnumerator Start()
    {
        UnityWebRequest www = UnityWebRequest.Get(URL);
        
        yield return www.SendWebRequest();

        string data = www.downloadHandler.text;
        
        Debug.Log(data);

        ParsingCharacterData(data);
    }
    
    // 데이터를 데이터 클래스에 맞게 파싱하는 기능
    private void ParsingCharacterData(string data)
    {
        Debug.Log(data);

        string[] rows = data.Split('\n'); // lines
        
        for (int i = 1; i < rows.Length; i++)
        {
            string[] cols = rows[i].Split(',');

            CharacterData characterData = new CharacterData(cols[0], cols[1], int.Parse(cols[2]), int.Parse(cols[3]));

            characters.Add(characterData);
        }
    }
}