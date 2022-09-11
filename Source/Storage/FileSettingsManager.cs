using Newtonsoft.Json;

namespace Source.Storage;

/// <summary>
/// Responsible to save the specified settings to a file in .json format.
/// </summary>
/// <typeparam name="T">The type of the settings.</typeparam>
public class FileSettingsManager<T> : ISettingsManager<T> 
    where T: Settings
{
    private const string SettingsFileName = "settings.json";
    
    private T? _settings;

    public FileSettingsManager()
    {
        try
        {
            LoadSettings();
        }
        catch (FileNotFoundException e)
        {
            // If the settings file does not exist, create a new one.
            SaveSettings();
        }
    }
    
    #region Implementation of ISettingsManager<out T>
    /// <inheritdoc />
    public T Settings => _settings ??= LoadSettings();

    /// <inheritdoc />
    /// <exception cref="ArgumentNullException"><paramref name="settings"/> is <see langword="null"/>.</exception>
    public void SaveSettings(Action<T>? settings = null)
    {
        ArgumentNullException.ThrowIfNull(_settings);
        
        settings?.Invoke(_settings);
        
        var text = JsonConvert.SerializeObject(_settings);
        File.WriteAllText(SettingsFileName, text);
    }
    #endregion
    
    private static T LoadSettings()
    {
        var text = File.ReadAllText(SettingsFileName);
        return JsonConvert.DeserializeObject<T>(text)!;
    }
}