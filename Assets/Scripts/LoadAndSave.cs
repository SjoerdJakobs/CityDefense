using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadAndSave : MonoBehaviour
{

    [SerializeField]
    private bool encrypted = true;

    private int numberOfCities;

    public void SaveCities()
    {
        numberOfCities = 0;
        if (!encrypted)
        {
            INIParser ini = new INIParser();
            ini.Open(Application.dataPath + "/SAVES/devSave.SAV");
            foreach (GameObject g in StaticCitiesList.Cities)
            {
                numberOfCities += 1;
                City cityInfo = g.GetComponent<City>();

                ini.WriteValue("City" + numberOfCities, "CityName", cityInfo._CityName);
                //City ints
                ini.WriteValue("City" + numberOfCities, "XPos", cityInfo._X);
                ini.WriteValue("City" + numberOfCities, "YPos", cityInfo._Y);
                ini.WriteValue("City" + numberOfCities, "ZPos", cityInfo._Z);
                ini.WriteValue("City" + numberOfCities, "Castle", cityInfo._Castle);
                ini.WriteValue("City" + numberOfCities, "KnightsCastle", cityInfo._KnightsCastle);
                ini.WriteValue("City" + numberOfCities, "Wall", cityInfo._Wall);
                ini.WriteValue("City" + numberOfCities, "SecondWall", cityInfo._SecondWall);
                ini.WriteValue("City" + numberOfCities, "ThirdWall", cityInfo._ThirdWall);
                ini.WriteValue("City" + numberOfCities, "GuardTowers", cityInfo._GuardTowers);
                ini.WriteValue("City" + numberOfCities, "Barracks", cityInfo._Barracks);
                ini.WriteValue("City" + numberOfCities, "PatrollCentre", cityInfo._PatrollCentre);
                ini.WriteValue("City" + numberOfCities, "Blacksmith", cityInfo._Blacksmith);
                ini.WriteValue("City" + numberOfCities, "Housing", cityInfo._Housing);
                ini.WriteValue("City" + numberOfCities, "Aphothecary", cityInfo._Aphothecary);
                ini.WriteValue("City" + numberOfCities, "Treasurery", cityInfo._Treasurery);
                ini.WriteValue("City" + numberOfCities, "Granary", cityInfo._Granary);
                ini.WriteValue("City" + numberOfCities, "StorageHouse", cityInfo._StorageHouse);
                ini.WriteValue("City" + numberOfCities, "TradingGuild", cityInfo._TradingGuild);
                ini.WriteValue("City" + numberOfCities, "School", cityInfo._School);
                ini.WriteValue("City" + numberOfCities, "Mill", cityInfo._Mill);
                ini.WriteValue("City" + numberOfCities, "GoldMine", cityInfo._GoldMine);
                ini.WriteValue("City" + numberOfCities, "IronMine", cityInfo._IronMine);
                ini.WriteValue("City" + numberOfCities, "CoalMine", cityInfo._CoalMine);
                ini.WriteValue("City" + numberOfCities, "WoodcuttersCamp", cityInfo._WoodcuttersCamp);
                ini.WriteValue("City" + numberOfCities, "WoodMill", cityInfo._WoodMill);
                ini.WriteValue("City" + numberOfCities, "Plains", cityInfo._Plains);
            }
            ini.WriteValue("NUMBER_OF_CITIES", "ammount", numberOfCities);
            ini.Close();
        }
        else
        {
            SaveCityData saveCityData = new SaveCityData();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.dataPath + "/SAVES/save.SAV");
            foreach (GameObject g in StaticCitiesList.Cities)
            {
                numberOfCities += 1;
                City cityInfo = g.GetComponent<City>();

                saveCityData.CityName = cityInfo._CityName;
                //City ints
                saveCityData.castle = cityInfo._Castle;
                saveCityData.knightsCastle = cityInfo._KnightsCastle;
                saveCityData.wall = cityInfo._Wall;
                saveCityData.secondWall = cityInfo._SecondWall;
                saveCityData.thirdWall = cityInfo._ThirdWall;
                saveCityData.guardTowers = cityInfo._GuardTowers;
                saveCityData.barracks = cityInfo._Barracks;
                saveCityData.patrollCentre = cityInfo._PatrollCentre;
                saveCityData.blacksmith = cityInfo._Blacksmith;
                saveCityData.housing = cityInfo._Housing;
                saveCityData.aphothecary = cityInfo._Aphothecary;
                saveCityData.treasurery = cityInfo._Treasurery;
                saveCityData.granary = cityInfo._Granary;
                saveCityData.storageHouse = cityInfo._StorageHouse;
                saveCityData.tradingGuild = cityInfo._TradingGuild;
                saveCityData.school = cityInfo._School;
                saveCityData.mill = cityInfo._Mill;
                saveCityData.goldMine = cityInfo._GoldMine;
                saveCityData.ironMine = cityInfo._IronMine;
                saveCityData.coalMine = cityInfo._CoalMine;
                saveCityData.woodcuttersCamp = cityInfo._WoodcuttersCamp;
                saveCityData.woodMill = cityInfo._WoodMill;
                saveCityData.plains = cityInfo._Plains;

            }

            bf.Serialize(file, saveCityData);
            file.Close();
        }       
    }

    
    public class SaveCityData
    {
        public string CityNumber;
        public string CityName;
        public float X;
        public float Y;
        public float Z;
        public int castle;
        public int knightsCastle;
        public int wall;
        public int secondWall;
        public int thirdWall;
        public int guardTowers;
        public int barracks;
        public int patrollCentre;
        public int blacksmith;
        public int housing;
        public int aphothecary;
        public int treasurery;
        public int granary;
        public int storageHouse;
        public int tradingGuild;
        public int school;
        public int mill;
        public int goldMine;
        public int ironMine;
        public int coalMine;
        public int woodcuttersCamp;
        public int woodMill;
        public int plains;
    }
}
