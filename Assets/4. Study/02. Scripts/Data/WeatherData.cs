using System.Collections.Generic;
using UnityEngine;

public class WeatherData
{
    [System.Serializable]
    public class Root
    {
        public Response response;
    }
    
    [System.Serializable]
    public class Response
    {
        public Header header;
        public Body body;
    }

    [System.Serializable]
    public class Header
    {
        public string resultCode;
        public string resultMsg;
    }

    [System.Serializable]
    public class Body
    {
        public string dataType;
        public Items items;
        public string pageNo;
        public string numOfRows;
        public string totalCount;
    }

    [System.Serializable]
    public class Items
    {
        public List<Item> item;
    }

    [System.Serializable]
    public class Item
    {
        public string category;
        public string fcstDate;
        public string fcstTime;
        public string fcstValue;
        public string baseDate;
        public string baseTime;
    }
}