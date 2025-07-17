using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;

public class ObjectMover : MonoBehaviour
{
    [SerializeField] private float dst = 10;
    [SerializeField] private float speed = 1f;
    private Subject<Unit> uniRxTest = new();
    private bool side;

    private void Start()
    {
        var _ = Task();
        uniRxTest.Subscribe(_ => { Debug.Log("UniRx works"); }).AddTo(this);
    }

    private async UniTask Task()
    {
        await UniTask.WaitForSeconds(2f);
        Debug.Log("Uni task works");
        await UniTask.WaitForSeconds(1f);
        uniRxTest.OnNext(default);
    }

    void Update()
    {
        transform.position += new Vector3((side ? 1 : -1) * speed * Time.deltaTime, 0, 0);
        
        if (side && transform.position.x >= dst)
        {
            side = !side;
        }
        
        if (!side && transform.position.x <= -dst)
        {
            side = !side;
        }
    }
}
