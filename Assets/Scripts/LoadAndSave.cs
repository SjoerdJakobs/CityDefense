using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class LoadAndSave : MonoBehaviour
{

    [SerializeField]
    private bool encrypted = true;

    [SerializeField]
    private City cityPrefab;

    [SerializeField]
    private string saveName;

    private int numberOfCities;

    public void SaveCities()
    {
        numberOfCities = 0;
        if (!encrypted)
        {
            INIParser ini = new INIParser();

            File.Delete(Application.dataPath + "/SAVES/" + saveName + ".SAV");
            ini.Open(Application.dataPath + "/SAVES/"+saveName+".SAV");
            ini.SectionDelete("NUMBER_OF_CITIES");
            foreach (GameObject g in StaticCitiesList.Cities)
            {
                numberOfCities += 1;
                City cityInfo = g.GetComponent<City>();
                //print(cityInfo._Y);
                ini.WriteValue("City" + numberOfCities, "CityName", cityInfo._CityName);
                //City ints
                ini.WriteValue("City" + numberOfCities, "XPos", cityInfo._X*10000f);
                ini.WriteValue("City" + numberOfCities, "YPos", cityInfo._Y*10000f);
                ini.WriteValue("City" + numberOfCities, "ZPos", cityInfo._Z*10000f);
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

                bf.Serialize(file, saveCityData);

            }
            CityCount cityCount = new CityCount();
            cityCount.cities = numberOfCities;

            bf.Serialize(file, cityCount);

            file.Close();
            
        }       
    }

    public void LoadCities()
    {
        if (!encrypted)
        {
            StaticCitiesList.Cities.Clear();
            INIParser ini = new INIParser();
            ini.Open(Application.dataPath + "/SAVES/" + saveName + ".SAV");
            for(int i = 1; i <= ini.ReadValue("NUMBER_OF_CITIES", "ammount", 0); i++)
            {
                City spawnedCity = (City) Instantiate(cityPrefab, new Vector3(ini.ReadValue("City" + i, "XPos", 0)/10000f, 
                                                    ini.ReadValue("City" + i, "YPos", 1)/10000f, 
                                                    ini.ReadValue("City" + i, "ZPos", 0)/10000f), 
                                                    Quaternion.identity);
                spawnedCity._CityName = ini.ReadValue("City" + i, "CityName", "City");
                //City ints
                spawnedCity._Castle = ini.ReadValue("City" + i, "Castle", 0);
                spawnedCity._KnightsCastle = ini.ReadValue("City" + i, "KnightsCastle", 0);
                spawnedCity._Wall = ini.ReadValue("City" + i, "Wall", 0);
                spawnedCity._SecondWall = ini.ReadValue("City" + i, "SecondWall", 0);
                spawnedCity._ThirdWall = ini.ReadValue("City" + i, "ThirdWall", 0);
                spawnedCity._GuardTowers = ini.ReadValue("City" + i, "GuardTowers", 0);
                spawnedCity._Barracks = ini.ReadValue("City" + i, "Barracks", 0);
                spawnedCity._PatrollCentre = ini.ReadValue("City" + i, "PatrollCentre", 0);
                spawnedCity._Blacksmith = ini.ReadValue("City" + i, "Blacksmith", 0);
                spawnedCity._Housing = ini.ReadValue("City" + i, "Housing", 0);
                spawnedCity._Aphothecary = ini.ReadValue("City" + i, "Aphothecary", 0);
                spawnedCity._Treasurery = ini.ReadValue("City" + i, "Treasurery", 0);
                spawnedCity._Granary = ini.ReadValue("City" + i, "Granary", 0);
                spawnedCity._StorageHouse = ini.ReadValue("City" + i, "StorageHouse", 0);
                spawnedCity._TradingGuild = ini.ReadValue("City" + i, "TradingGuild", 0);
                spawnedCity._School = ini.ReadValue("City" + i, "School", 0);
                spawnedCity._Mill = ini.ReadValue("City" + i, "Mill", 0);
                spawnedCity._GoldMine = ini.ReadValue("City" + i, "GoldMine", 0);
                spawnedCity._IronMine = ini.ReadValue("City" + i, "IronMine", 0);
                spawnedCity._CoalMine = ini.ReadValue("City" + i, "CoalMine", 0);
                spawnedCity._WoodcuttersCamp = ini.ReadValue("City" + i, "WoodcuttersCamp", 0);
                spawnedCity._WoodMill = ini.ReadValue("City" + i, "WoodMill", 0);
                spawnedCity._Plains = ini.ReadValue("City" + i, "Plains", 0);
            }

            ini.Close();
        }
        /*else
        {
            BinaryFormatter bf = new BinaryFormatter();
            if (File.Exists(Application.dataPath + "/SAVES/save.SAV"))
            {
                FileStream file = File.Open(Application.dataPath + "/SAVES/save.SAV", FileMode.Open);
                SaveCityData saveCityData = (SaveCityData)bf.Deserialize(file);

                _CityName = saveCityData.CityName;
                //City ints
                _Castle = saveCityData.castle;
                _KnightsCastle = saveCityData.knightsCastle;
                _Wall = saveCityData.wall;
                _SecondWall = saveCityData.secondWall;
                _ThirdWall = saveCityData.thirdWall;
                _GuardTowers = saveCityData.guardTowers;
                _Barracks = saveCityData.barracks;
                _PatrollCentre = saveCityData.patrollCentre;
                _Blacksmith = saveCityData.blacksmith;
                _Housing = saveCityData.housing;
                _Aphothecary = saveCityData.aphothecary;
                _Treasurery = saveCityData.treasurery;
                _Granary = saveCityData.granary;
                _StorageHouse = saveCityData.storageHouse;
                _TradingGuild = saveCityData.tradingGuild;
                _School = saveCityData.school;
                _Mill = saveCityData.mill;
                _GoldMine = saveCityData.goldMine;
                _IronMine = saveCityData.ironMine;
                _CoalMine = saveCityData.coalMine;
                _WoodcuttersCamp = saveCityData.woodcuttersCamp;
                _WoodMill = saveCityData.woodMill;
                _Plains = saveCityData.plains;

                file.Close();
            }
        }
        Debug.Log("loaded ");
        //moni = PlayerPrefs.GetInt("Moni");*/
    }
    [System.Serializable]
    public class CityCount
    {
        public int cities;
    }

    [System.Serializable]
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
