using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanguageSingleton : MonoBehaviour
{
    private static LanguageSingleton instance;

    public LanguageType currentLanguage;

    void Awake() //Do not destroy this GameObject
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public static LanguageSingleton Instance //Get the instance or Singleton
    {
        get { return instance ?? (instance = new GameObject("LanguageSingleton").AddComponent<LanguageSingleton>()); }
    }
}

public enum LanguageType
{
    CAT,
    ESP,
    ENG
}
