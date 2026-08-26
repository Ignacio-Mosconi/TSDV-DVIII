using System.Threading.Tasks;
using UnityEngine;

public class TaskExample : MonoBehaviour
{
    async void Start ()
    {
        Debug.Log("Initializing random number...");

        int randomNumber = await GetRandomNumberAsync(1, 10);

        Debug.Log($"Random number: {randomNumber}");
    }

    
    private async Task<int> GetRandomNumberAsync (int min, int max)
    {
        int randomDelay = Random.Range(1000, 5000);

        await Task.Delay(randomDelay);

        int randomNumber = Random.Range(min, max);

        return randomNumber;
    }
}