using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    public int CoinCount { get; private set; }

    public void Increase(int count)
    {
        CoinCount += count;
        Debug.Log(CoinCount);
    }
}
