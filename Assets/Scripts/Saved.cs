using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Saved : MonoBehaviour {

    [SerializeField]
    private bool encrypted = true;

    private void Awake()
    {
        //StaticCitiesList.Cities.Add(gameObject);
    }
    /// <summary>
    /// in this script is all the info over the Game
    /// </summary>


    [SerializeField]
    private string cityName;
    public string _CityName
    {
        get { return cityName; }
        set { cityName = value; }
    }

        #region "City ints"
    [SerializeField]
    protected int castle;
    public int _Castle
    {
        get { return castle; }
        set { castle = value; }
    }
    [SerializeField]
    private int knightsCastle;
    public int _KnightsCastle
    {
        get { return knightsCastle; }
        set { knightsCastle = value; }
    }
    [SerializeField]
    private int wall;
    public int _Wall
    {
        get { return wall; }
        set { wall = value; }
    }
    [SerializeField]
    private int secondWall;
    public int _SecondWall
    {
        get { return secondWall; }
        set { secondWall = value; }
    }
    [SerializeField]
    private int thirdWall;
    public int _ThirdWall
    {
        get { return thirdWall; }
        set { thirdWall = value; }
    }
    [SerializeField]
    private int guardTowers;
    public int _GuardTowers
    {
        get { return guardTowers; }
        set { guardTowers = value; }
    }
    [SerializeField]
    private int barracks;
    public int _Barracks
    {
        get { return barracks; }
        set { barracks = value; }
    }
    [SerializeField]
    private int patrollCentre;
    public int _PatrollCentre
    {
        get { return patrollCentre; }
        set { patrollCentre = value; }
    }
    [SerializeField]
    private int blacksmith;
    public int _Blacksmith
    {
        get { return blacksmith; }
        set { blacksmith = value; }
    }
    [SerializeField]
    private int housing;
    public int _Housing
    {
        get { return housing; }
        set { housing = value; }
    }
    [SerializeField]
    private int aphothecary;
    public int _Aphothecary
    {
        get { return aphothecary; }
        set { aphothecary = value; }
    }
    [SerializeField]
    private int treasurery;
    public int _Treasurery
    {
        get { return treasurery; }
        set { treasurery = value; }
    }
    [SerializeField]
    private int granary;
    public int _Granary
    {
        get { return granary; }
        set { granary = value; }
    }
    [SerializeField]
    private int storageHouse;
    public int _StorageHouse
    {
        get { return storageHouse; }
        set { storageHouse = value; }
    }
    [SerializeField]
    private int tradingGuild;
    public int _TradingGuild
    {
        get { return tradingGuild; }
        set { tradingGuild = value; }
    }
    [SerializeField]
    private int school;
    public int _School
    {
        get { return school; }
        set { school = value; }
    }
    [SerializeField]
    private int mill;
    public int _Mill
    {
        get { return mill; }
        set { mill = value; }
    }
    [SerializeField]
    private int goldMine;
    public int _GoldMine
    {
        get { return goldMine; }
        set { goldMine = value; }
    }
    [SerializeField]
    private int ironMine;
    public int _IronMine
    {
        get { return ironMine; }
        set { ironMine = value; }
    }
    [SerializeField]
    private int coalMine;
    public int _CoalMine
    {
        get { return coalMine; }
        set { coalMine = value; }
    }
    [SerializeField]
    private int woodcuttersCamp;
    public int _WoodcuttersCamp
    {
        get { return woodcuttersCamp; }
        set { woodcuttersCamp = value; }
    }
    [SerializeField]
    private int woodMill;
    public int _WoodMill
    {
        get { return woodMill; }
        set { woodMill = value; }
    }
    [SerializeField]
    private int plains;
    public int _Plains
    {
        get { return plains; }
        set { castle = value; }
    }
    #endregion

    public void saveResource()
    {
        if (!encrypted)
        {
            INIParser ini = new INIParser();
            ini.Open(Application.dataPath + "/SAVES/devSave.SAV");

            ini.WriteValue("City", "CityName", _CityName);
            //City ints
            ini.WriteValue("City", "Castle", _Castle);
            ini.WriteValue("City", "KnightsCastle", _KnightsCastle);
            ini.WriteValue("City", "Wall", _Wall);
            ini.WriteValue("City", "SecondWall", _SecondWall);
            ini.WriteValue("City", "ThirdWall", _ThirdWall);
            ini.WriteValue("City", "GuardTowers", _GuardTowers);
            ini.WriteValue("City", "Barracks", _Barracks);
            ini.WriteValue("City", "PatrollCentre", _PatrollCentre);
            ini.WriteValue("City", "Blacksmith", _Blacksmith);
            ini.WriteValue("City", "Housing", _Housing);
            ini.WriteValue("City", "Aphothecary", _Aphothecary);
            ini.WriteValue("City", "Treasurery", _Treasurery);
            ini.WriteValue("City", "Granary", _Granary);
            ini.WriteValue("City", "StorageHouse", _StorageHouse);
            ini.WriteValue("City", "TradingGuild", _TradingGuild);
            ini.WriteValue("City", "School", _School);
            ini.WriteValue("City", "Mill", _Mill);
            ini.WriteValue("City", "GoldMine", _GoldMine);
            ini.WriteValue("City", "IronMine", _IronMine);
            ini.WriteValue("City", "CoalMine", _CoalMine);
            ini.WriteValue("City", "WoodcuttersCamp", _WoodcuttersCamp);
            ini.WriteValue("City", "WoodMill", _WoodMill);
            ini.WriteValue("City", "Plains", _Plains);


            ini.Close();
        }
        else
        {
            SaveCityData saveCityData = new SaveCityData();
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.dataPath + "/SAVES/save.SAV");

            saveCityData.CityName = _CityName;
            //City ints
            saveCityData.castle = _Castle;
            saveCityData.knightsCastle = _KnightsCastle;
            saveCityData.wall = _Wall;
            saveCityData.secondWall = _SecondWall;
            saveCityData.thirdWall = _ThirdWall;
            saveCityData.guardTowers = _GuardTowers;
            saveCityData.barracks = _Barracks;
            saveCityData.patrollCentre = _PatrollCentre;
            saveCityData.blacksmith = _Blacksmith;
            saveCityData.housing = _Housing;
            saveCityData.aphothecary = _Aphothecary;
            saveCityData.treasurery = _Treasurery;
            saveCityData.granary = _Granary;
            saveCityData.storageHouse = _StorageHouse;
            saveCityData.tradingGuild = _TradingGuild;
            saveCityData.school = _School;
            saveCityData.mill = _Mill;
            saveCityData.goldMine = _GoldMine;
            saveCityData.ironMine = _IronMine;
            saveCityData.coalMine = _CoalMine;
            saveCityData.woodcuttersCamp = _WoodcuttersCamp;
            saveCityData.woodMill = _WoodMill;
            saveCityData.plains = _Plains;


            bf.Serialize(file, saveCityData);
            file.Close();
            Debug.Log(Application.persistentDataPath);
            Debug.Log("saved ");
            //PlayerPrefs.SetInt("Moni", moni);
        }
    }

    public void loadResource()
    {
        if (!encrypted)
        {
            INIParser ini = new INIParser();
            ini.Open(Application.dataPath + "/SAVES/devSave.SAV");

            _CityName = ini.ReadValue("City", "CityName", "City");
            //City ints
            _Castle = ini.ReadValue("City", "Castle", 0);
            _KnightsCastle = ini.ReadValue("City", "KnightsCastle", 0);
            _Wall = ini.ReadValue("City", "Wall", 0);
            _SecondWall = ini.ReadValue("City", "SecondWall", 0);
            _ThirdWall = ini.ReadValue("City", "ThirdWall", 0);
            _GuardTowers = ini.ReadValue("City", "GuardTowers", 0);
            _Barracks = ini.ReadValue("City", "Barracks", 0);
            _PatrollCentre = ini.ReadValue("City", "PatrollCentre", 0);
            _Blacksmith = ini.ReadValue("City", "Blacksmith", 0);
            _Housing = ini.ReadValue("City", "Housing", 0);
            _Aphothecary = ini.ReadValue("City", "Aphothecary", 0);
            _Treasurery = ini.ReadValue("City", "Treasurery", 0);
            _Granary = ini.ReadValue("City", "Granary", 0);
            _StorageHouse = ini.ReadValue("City", "StorageHouse", 0);
            _TradingGuild = ini.ReadValue("City", "TradingGuild", 0);
            _School = ini.ReadValue("City", "School", 0);
            _Mill = ini.ReadValue("City", "Mill", 0);
            _GoldMine = ini.ReadValue("City", "GoldMine", 0);
            _IronMine = ini.ReadValue("City", "IronMine", 0);
            _CoalMine = ini.ReadValue("City", "CoalMine", 0);
            _WoodcuttersCamp = ini.ReadValue("City", "WoodcuttersCamp", 0);
            _WoodMill = ini.ReadValue("City", "WoodMill", 0);
            _Plains = ini.ReadValue("City", "Plains", 0);

            ini.Close();
        }
        else
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
        //moni = PlayerPrefs.GetInt("Moni");
    }

    [System.Serializable]
    public class SaveCityData
    {
        public string CityName;
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
