using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System;
public class DataPersistenceManager : MonoBehaviour
{
    [Header("File Storage Config")]
    [SerializeField] private string fileName;

    private GameData gameDataJSON;
    private List<IDataPersistence> dataPersistenceObjects;
    //private string selectedProfileId = "test"; //(New)

    private FileDataHandler dataHandler;
    public static DataPersistenceManager instance { get; private set; }
    public OfflineProgression offlineScript;

    private void Update()
    {
        if (FileDataHandler.hadToBackup == true)
        {
            //testingObject.SetActive(true);
            FileDataHandler.hadToBackup = false;
        }
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Data Persistance Manager in the scene");
        }
        instance = this;
    }

    private void Start()
    {
        this.dataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        this.dataPersistenceObjects = FindAllDataPersistenceObjects();
        LoadGame();

        if(MobileScript.isMobile == false) { InvokeRepeating("SaveGame", 5f, 15f); }
        else { InvokeRepeating("SaveGame", 3f, 5f); }
      
    }

    public void NewGame()
    {
        this.gameDataJSON = new GameData();
    }

    public GameObject testingObject;

    public void LoadGame()
    {
        this.gameDataJSON = dataHandler.Load("", true);  //(NEW) string

        if (this.gameDataJSON == null)
        {
            Debug.Log("No data was found. Initialzing data to defaults");
            NewGame();
        }

        foreach (IDataPersistence dataPersistanceObj in dataPersistenceObjects)
        {
            dataPersistanceObj.LoadData(gameDataJSON);
        }

        //Debug.Log("Loaded all variables");
    }

    public GameObject saveGamePopUp;
    public static int saveIncrement;

    public void SaveGame()
    {
        if (Prestige.isPrestiged == false)
        {
            PlayerPrefs.SetString("OfflineProgression", DateTime.Now.ToString());
            saveIncrement += 1;
            if(clickSave == true) { clickSave = false; saveIncrement = 1; }
            //saveGamePopUp.SetActive(true);
            //StartCoroutine(waitSet());

            foreach (IDataPersistence dataPErsistenceObj in dataPersistenceObjects)
            {
                dataPErsistenceObj.SaveData(ref gameDataJSON);
            }

            if(GameData.isDemo == false) { if (offlineScript != null) { offlineScript.SetTime(); } }
            dataHandler.Save(gameDataJSON, ""); //(NEW) string
        }
    }

    IEnumerator waitSet()
    {
        yield return new WaitForSeconds(0.8f);
        //saveGamePopUp.SetActive(false);
    }

    private void OnApplicationQuit()
    {
        //SaveGame();
    }

    private List<IDataPersistence> FindAllDataPersistenceObjects()
    {
        IEnumerable<IDataPersistence> dataPersistenceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistence>();

        return new List<IDataPersistence>(dataPersistenceObjects);
    }

    public AudioManager audioManager;
    public bool clickSave;

    public void SaveTheGameData()
    {
        clickSave = true;
        audioManager.Play("Save");
        SaveGame();
    }
}
