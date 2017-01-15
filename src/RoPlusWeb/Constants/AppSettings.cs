using System;
using Microsoft.Extensions.Configuration;

namespace RoPlusWeb.Constants {
  public class AppSettings {
    const string AppSettingsKey = "AppSettings";

    private AppSettings() {
      //Singleton Constructor
    }

    public void LoadConfiguration( IConfigurationRoot configuration ) {
      _appSettings = configuration.GetSection( AppSettingsKey );
      BuildAppSettings();
    }

    private static AppSettings _instance;
    private IConfigurationSection _appSettings;

    private void BuildAppSettings() {
      RepositoryUrl = GetStringFromAppSetting( "repositoryUrl" );
    }

   
    public static AppSettings Instance {
      get {
        if ( _instance == null ) {
          _instance = new AppSettings();
        }
        return _instance;
      }
    }

    public string RepositoryUrl { get; private set; }

    private int GetIntFromAppSetting( string key ) {
      int setting;
      if ( !int.TryParse( GetStringFromAppSetting( key ), out setting ) ) {
        throw new Exception( $"Setting with key {key} is not an integer value" );
      }

      return setting;
    }

    private bool GetBoolFromAppSetting( string key ) {
      bool setting;
      if ( !bool.TryParse( GetStringFromAppSetting( key ), out setting ) ) {
        throw new Exception( $"Setting with key {key} is not an boolean value" );
      }

      return setting;
    }

    private string GetStringFromAppSetting( string key ) {
      var setting = _appSettings.GetValue<string>( key );
      if ( string.IsNullOrEmpty( setting ) ) {
        throw new Exception( $"Setting with key {key} not found" );
      }
      return setting;
    }
  }
}
