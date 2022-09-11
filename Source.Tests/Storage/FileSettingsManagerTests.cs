using NUnit.Framework;
using Source.Storage;

namespace Source.Tests.Storage;

[TestFixture]
public class FileSettingsManagerTests 
{
    internal class TestSettings : Settings
    {
        public string? Test { get; set; } = "test text";
    }

    private ISettingsManager<TestSettings> settingsManager;

    [SetUp]
    public void SetUp()
    {
        settingsManager = new FileSettingsManager<TestSettings>();
    }

    [Test]
    public void SettingsProperty_DoesNotThrow_WhenCalledAfterInit()
    {
        Assert.DoesNotThrow(() =>
        {
            var settings = settingsManager.Settings;
        });
    }

    [Test]
    public void Save_SavesSuccessfully_WhenActionIsProvided()
    {
        settingsManager.SaveSettings(s => s.Test = "Changed text");

        Assert.That(settingsManager.Settings.Test, Is.EqualTo("Changed text"));
    }

    [Test]
    public void SettingsProperty_CreatesNewFile_AfterFirstCall()
    {
        var file = "settings.json";
        if (File.Exists(file))
            File.Delete(file);

        settingsManager = new FileSettingsManager<TestSettings>();

        Assert.That(File.Exists(file));
    }
}