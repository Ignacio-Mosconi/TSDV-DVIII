using UnityEngine;
using TMPro;

[RequireComponent(typeof(TMP_Text))]
public class VersionText : MonoBehaviour
{
    [SerializeField] private string versionPrefix;


    void Awake ()
    {
        TMP_Text versionText = GetComponent<TMP_Text>();
        versionText.text = $"{versionPrefix}{Application.version}";
    }
}