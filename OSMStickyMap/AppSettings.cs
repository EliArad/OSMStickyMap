using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
 
 

namespace OSMStickyMap
{
     
    public enum OVERLAYS
    {
        MARKERS,
        DRAWING,
        LINE
    }
    public enum MAP_ACCESS_MODE
    {
        Offline,
        Online,
        Both
    } 

    public enum MAP_CORDINATE
    {
        OFF,
        LAT_LON,
        ECEF_XYZ
    }

    public struct LastWinPos
    {
        public int x;
        public int y;
    }


    public struct LastWinPosition
    {
        public LastWinPos LoadMapWindow;
        public LastWinPos MapSaveLocationWindow;
        public LastWinPos FormSelectCity;
    }

    public class AppConfig
    {  
        public string OSMBaseDir;
        public Color lineColor;
        public MAP_ACCESS_MODE MapAccessMode;
        public MAP_CORDINATE ShowMapCoordinate;
        public bool ShowMapBorder;       
        public bool LoadWithZoom;        
        public int DownloadMissingTile;
        public double latestMapLatLocation;
        public double latestMapLonLocation;
        public double latestMapZoom;        
        public bool SupportOnTrackOnMap;
        public int Top;
        public int Left;
        public int Width;
        public int Height;
        public string MapProvider;
        public double LastLoadMapLat;
        public double LastLoadMapLon;
        public int LastLoadMapZoom;
        public LastWinPosition lastwinPos;

    }

    public sealed class AppSettings
    {
        private static AppSettings instance = null;
        private static readonly object padlock = new object();
        AppConfig m_config;
        string m_fileName;

        AppSettings()
        {
        }
        public AppConfig Config
        {
            get
            {
                return m_config;
            }
        }

         
        public void Default()
        {              
            m_config.lineColor = Color.Black;
            m_config.MapAccessMode = MAP_ACCESS_MODE.Offline;
            m_config.OSMBaseDir = @"c:\OSMTiles";
            m_config.MapProvider = "OpenStreetMapProvider";
            m_config.lineColor = Color.Black;
            m_config.MapAccessMode =  MAP_ACCESS_MODE.Both;
            m_config.ShowMapCoordinate =  MAP_CORDINATE.LAT_LON;
            m_config.ShowMapBorder = false;
            m_config.LoadWithZoom = false;
            m_config.DownloadMissingTile = 0;
            m_config.latestMapLatLocation = 32.4311;
            m_config.latestMapLonLocation = 34.3341;
            m_config.latestMapZoom = 9.0;
            m_config.SupportOnTrackOnMap= false;
            m_config.Top = 0;
            m_config.Left = 0;
            m_config.Width = 800;
            m_config.Height = 800;
            m_config.MapProvider = "BingHybridMap";
             

        }
         
        public string Save()
        {
            try
            {
                
                
                string json = JsonConvert.SerializeObject(m_config);
                string jsonFormatted = JValue.Parse(json).ToString(Formatting.Indented);                    
                File.WriteAllText(m_fileName, jsonFormatted);
               
                return "ok";
            }
            catch (Exception err)
            {
                return err.Message;
            }
        }
        
        void Validate()
        {
            
             
        }
        public string Load(string fileName, bool defaultIfNeed = true)
        {
            try
            {
                m_fileName = fileName;
                if (File.Exists(fileName) == false)
                {
                    m_config = new AppConfig();
                    if (defaultIfNeed == true)
                        Default();
                    Save();
                    return "file not found";
                }
                string text = File.ReadAllText(m_fileName);
                m_config = JsonConvert.DeserializeObject<AppConfig>(text);
                if (m_config == null)
                {
                    m_config = new AppConfig();
                    if (defaultIfNeed == true)
                        Default();
                    Save();
                }

                 
                Validate();
                return "ok";
            }
            catch (Exception err)
            {
                m_config = new AppConfig();
                Default();
                Validate();
                Save();
                return err.Message;
            }
        }
      
        public static AppSettings Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new AppSettings();
                        }
                    }
                }
                return instance;
            }
        }
    }

}
