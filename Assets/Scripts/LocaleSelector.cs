using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LocaleSelector : MonoBehaviour
{
    private void Start()
    {
        int ID = PlayerPrefs.GetInt("LocaleKey", 0);
        ChangeLocale(ID);
    }
    private bool active = false;
    public void ChangeLocale(int localeId)
    {   if (active == true )
        return;
        StartCoroutine(SetLocale(localeId));
    }
    // Start is called before the first frame update
   IEnumerator SetLocale(int _localeID)

    {
        active = true;
        yield return LocalizationSettings.InitializationOperation;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[_localeID];
        active = false;
    }
}
