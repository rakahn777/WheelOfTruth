using UnityEngine;
using System.Collections;
using nFury.Utils.Core;
using System.Text;
using System;

public class ConfigManager
{
    private const string CONFIG_FOLDER = "Config/";

    public static readonly string[] preloadConfig =
    {
        AssetsPath.WHEEL_CONFIG,
    };

    private WheelConfig wheelConfig;

    public ConfigManager()
    {
        if (!Service.IsSet<ConfigManager>()) Service.Set(this);
        for (int i = 0; i < preloadConfig.Length; ++i)
        {
            string name = preloadConfig[i];
            var asset = Resources.Load<TextAsset>(CONFIG_FOLDER + name);
            MapValue(name, asset.text);
        }
    }

    public void MapValue(string name, string text)
    {
        try
        {
            var serialization = Service.Get<ISerialization>();
            byte[] bytes = Encoding.Default.GetBytes(text);

            if (name.Equals(AssetsPath.WHEEL_CONFIG))
            {
                ReadWheelConfig(bytes, serialization);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Map file error: " + name + " " + e);
        }
    }

    #region GetConfig

    public WheelConfig GetWheelConfig()
    {
        return wheelConfig;
    }
    #endregion

    #region Read Config

    private void ReadWheelConfig(byte[] bytes, ISerialization serialization)
    {
        wheelConfig = serialization.Deserialize<WheelConfig>(bytes);
    }
    #endregion
}
