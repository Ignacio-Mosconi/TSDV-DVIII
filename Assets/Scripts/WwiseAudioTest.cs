using UnityEngine;

public class WwiseAudioTest : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event shootEvent;


    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            AkUnitySoundEngine.PostEvent(shootEvent.Id, gameObject);
    }
}