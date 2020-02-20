using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainController : MonoBehaviour
{

    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private ProgressBar progressBar;
    [SerializeField] private Transform coinsFlyTarget;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private Transform uiTransform;

    [FormerlySerializedAs("checkpointForCheck")] [SerializeField]
    private BaseCheckpointView baseCheckpointForCheck;

    public void OnPressPlay()
    {
        Debug.Log("Start");
        StartCoroutine(PlayAnimation());
    }

    public void OnPressRestart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator PlayAnimation()
    {
        const int target = 640;
        const float speed = 1f;
        const float delay = 1f;
        const float delayBetweenCoins = 0.2f;
        const int coins = 5;

        var counterValue = 100;
        progressBar.SetTarget(target);

        yield return new WaitForSeconds(delay);
        counterValue = progressBar.MoveTo(400, 140, counterValue, speed);
        yield return new WaitForSeconds(speed);
        baseCheckpointForCheck.Activate();
        coinsCounter.AddCoins(140,delayBetweenCoins*coins+speed);
        yield return FlyCoins(baseCheckpointForCheck.transform.position, coinsFlyTarget.position, speed, coins, delayBetweenCoins);
        yield return new WaitForSeconds(delay * 2);
        counterValue = progressBar.MoveTo(640, 200, counterValue, speed);
    }

    private IEnumerator FlyCoins(Vector2 from, Vector2 to, float speed, int count, float delay)
    {
        for (var i = 0; i < count; i++)
        {
            var coin = Instantiate(coinPrefab, uiTransform).GetComponent<FlyCoin>();
            coin.transform.position = from;
            coin.Fly(to, speed);
            yield return new WaitForSeconds(delay);
        }
    }
}
