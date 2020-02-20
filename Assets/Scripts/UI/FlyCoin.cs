using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FlyCoin : MonoBehaviour
{
    [SerializeField] private Transform imageTransform;
    public void Fly(Vector2 to, float speed)
    {
        var canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 0f;

        canvasGroup.DOFade(1f, speed / 4f);

        var position = new Vector3(
            to.x - transform.position.x,
            to.y - transform.position.y
            );

        transform
            .DOBlendableMoveBy(position, speed)
            .SetEase(Ease.InOutSine)
            .OnComplete(() => Destroy(gameObject));

        transform
            .DOBlendableMoveBy(Random.insideUnitCircle, speed / 2f)
            .SetLoops(2, LoopType.Yoyo)
            .SetEase(Ease.InOutSine);
    }
}
