using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public const int columns = 9;
    public const int rows = 2;

    public const float Xspace = 2.3f;
    public const float Yspace = -3f;

    [SerializeField] private MainImage startObject;
    [SerializeField] private Sprite[] images;

    private int[] Randomiser(int[] locations)
    {
        int[] array = locations.Clone() as int[];
        for(int i=0; i < array.Length; i++)
        {
            int newArray = array[i];
            int j = Random.Range(i, array.Length);
            array[i] = array[j];
            array[j] = newArray;
        }
        return array;
    }

    private void Start()
    {
        int[] locations = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7, 8, 8 };
        locations = Randomiser(locations);

        Vector3 startPosition = startObject.transform.position;

        for(int i = 0; i < columns; i++)
        {
            for(int j = 0; j < rows; j++)
            {
                MainImage gameImage;
                if(i == 0 && j == 0)
                {
                    gameImage = startObject;
                }
                else
                {
                    gameImage = Instantiate(startObject) as MainImage;
                }

                int index = j * columns + i;
                int id = locations[index];
                gameImage.ChangeSprite(id, images[id]);

                float positionX = (Xspace * i) + startPosition.x;
                float positionY = (Yspace * j) + startPosition.y;

                gameImage.transform.position = new Vector3(positionX, positionY, startPosition.z);
            }
        }
    }

    private MainImage firstOpen;
    private MainImage secondOpen;

    private int player1 = 0;
    private int player2 = 0;

    [SerializeField] private TextMesh player1Text;
    [SerializeField] private TextMesh player2Text;

    public bool canOpen
    {
        get { return secondOpen == null; }
    }

    public void imageOpened(MainImage startObject)
    {
        if(firstOpen == null)
        {
            firstOpen = startObject;
        }
        else
        {
            secondOpen = startObject;
            StartCoroutine(CheckGuessed());
        }
    }

    private IEnumerator CheckGuessed()
    {
        if (firstOpen.spriteId == secondOpen.spriteId)
        {
            player1++;
            player1Text.text = "Player1: " + player1;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();
        }

        if (firstOpen.spriteId == secondOpen.spriteId)
        {
            player2++;
            player2Text.text = "Player2: " + player2;
        }
        else
        {
            yield return new WaitForSeconds(0.5f);

            firstOpen.Close();
            secondOpen.Close();
        }
        
        firstOpen = null;
        secondOpen = null;
    }

    public void Restart()
    {
        SceneManager.LoadScene("MainScene");
    }
}
