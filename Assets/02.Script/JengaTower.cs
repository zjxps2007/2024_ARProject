using UnityEngine;

public class JengaTower : MonoBehaviour
{
    public GameObject blockPrefab; // 블록 프리팹
    public int layers = 10; // 젠가 타워의 층 수

    void Start()
    {
        BuildTower();
    }

    void BuildTower()
    {
        float blockHeight = blockPrefab.transform.localScale.y;
        float blockWidth = blockPrefab.transform.localScale.x;
        float blockDepth = blockPrefab.transform.localScale.z;

        // 층수 만큼 반복
        for (int i = 0; i < layers; i++)
        {
            // 층수에 맞는 대로 배치
            for (int j = 0; j < 3; j++)
            {
                //홀수층에서는 z축으로 블록을 배치
                float xOffset;
                float zOffset;
                
                if (i % 2 == 0)
                {
                    xOffset = j * blockWidth - blockWidth;
                }
                else
                {
                    xOffset = 0;
                }
                
                if (i % 2 == 0)
                {
                    zOffset = 0.05f;
                }
                else
                {
                    zOffset = j * (blockDepth - 0.1f);
                }
                Vector3 position = this.transform.position + new Vector3(xOffset, i * blockHeight, zOffset);

                Quaternion rotation = Quaternion.Euler(0, (i % 2 == 0) ? 0 : 90, 0);
                Instantiate(blockPrefab, position, rotation);
            }
        }
    }
}