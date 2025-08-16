using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class XmlParser : MonoBehaviour
{
    [System.Serializable]
    public class CharacterData
    {
        public string CharID;
        public string Name;
        public int HP;
        public int Attack;
    }

    [System.Serializable]
    [XmlRoot("Characters")]
    public class CharacterList
    {
        [XmlElement("Character")]
        public List<CharacterData> characters;
    }
    
    public List<CharacterData> characterDatas = new List<CharacterData>();

    void Start()
    {
        var dataFile = Resources.Load<TextAsset>("XmlData");
        string data = dataFile.text;

        ParsingCharacterXmlData(data);
    }

    private void ParsingCharacterXmlData(string data)
    {
        Debug.Log(data);
        
        XmlSerializer serializer = new XmlSerializer(typeof(CharacterList));

        using (StringReader reader = new StringReader(data))
        {
            CharacterList loadedData = (CharacterList)serializer.Deserialize(reader);
            characterDatas = loadedData.characters;
        }

        foreach (CharacterData cData in characterDatas)
        {
            Debug.Log($"{cData.CharID} / {cData.Name} / {cData.HP} / {cData.Attack}");
        }
    }
}