using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ColorChangerAsync : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color targetColor;
    [SerializeField] private AnimationCurve crossFadeCurve;
    [SerializeField, Range(0f, 10f)] private float crossFadeDuration;

    private MeshRenderer meshRenderer;
    private CancellationTokenSource crossFadeTaskTokenSource;

    
    void Awake ()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.material.color = startColor;
    }

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (crossFadeTaskTokenSource != null)
                StopCrossFade();

            StartCrossFade();
        }
    }


    private async void DoCrossFading ()
    {
        float timer = 0f;

        while (timer < crossFadeDuration)
        {
            if (crossFadeTaskTokenSource != null && crossFadeTaskTokenSource.IsCancellationRequested)
                return;

            float t = crossFadeCurve.Evaluate(timer / crossFadeDuration);

            meshRenderer.material.color = Color.Lerp(startColor, targetColor, t);

            await UniTask.WaitForEndOfFrame(crossFadeTaskTokenSource.Token).SuppressCancellationThrow();
            
            timer += Time.deltaTime;
        }

        FinishCrossFade();
    }

    private void StartCrossFade ()
    {
        crossFadeTaskTokenSource = new CancellationTokenSource();
        DoCrossFading();
    }

    private void StopCrossFade ()
    {
        crossFadeTaskTokenSource?.Cancel();
        FinishCrossFade();
    }

    private void FinishCrossFade ()
    {
        meshRenderer.material.color = targetColor;
        (targetColor, startColor) = (startColor, targetColor);
        crossFadeTaskTokenSource = null;
    }
}
