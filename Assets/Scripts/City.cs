using UnityEngine;
using System.Collections;

public class City : MonoBehaviour {

    private void Awake()
    {
        StaticCitiesList.Cities.Add(gameObject);
        _X = transform.position.x;
        _Y = transform.position.y;
        _Z = transform.position.z;
    }
    /// <summary>
    /// in this script is all the info over the Game
    /// </summary>
    [SerializeField]
    private int cityOwner;
    public int _CityOwner
    {
        get { return cityOwner; }
        set { cityOwner = value; }
    }

    [SerializeField]
    private string cityName;
    public string _CityName
    {
        get { return cityName; }
        set { cityName = value; }
    }

    [SerializeField]
    private float x;
    public float _X
    {
        get { return x; }
        set { x = value; }
    }
    [SerializeField]
    private float y;
    public float _Y
    {
        get { return y; }
        set { y = value; }
    }
    [SerializeField]
    private float z;
    public float _Z
    {
        get { return z; }
        set { z = value; }
    }

    #region "City ints"
    [SerializeField]
    private int castle;
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
}
