using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ShareButton : MonoBehaviour
{
    public ChangeTarget changeTarget;
    public string mapName;
    public string currentWeapon;

    public void ClickShareMessage()
    {
        int currentMap = SceneManager.GetActiveScene().buildIndex;
        currentWeapon = changeTarget.playerWeapon;

        int highScore = PlayerPrefs.GetInt("highScore"+currentWeapon+currentMap, 0);

        if (currentMap == 2)
        {
            mapName = "Inferno";
        }
        else if (currentMap == 3)
        {
            mapName = "Dust2";
        }
        else if (currentMap == 4)
        {
            mapName = "Cache";
        }
        else if (currentMap == 1)
        {
            mapName = "Mirage";
        }
        
        StartCoroutine(TakeScreenshotAndShare(highScore));
    }

    private IEnumerator TakeScreenshotAndShare(float highScoreShare)
    {
        yield return new WaitForEndOfFrame();

        Texture2D ss = new Texture2D( Screen.width, Screen.height, TextureFormat.RGB24, false );
        ss.ReadPixels( new Rect( 0, 0, Screen.width, Screen.height ), 0, 0 );
        ss.Apply();

        string filePath = Path.Combine( Application.temporaryCachePath, "shared-img.png" );
        File.WriteAllBytes( filePath, ss.EncodeToPNG() );

        // To avoid memory leaks
        Destroy( ss );

        new NativeShare().AddFile( filePath )
            .SetSubject( "Training Grounds" ).SetText( "I've got new highscore: "+ highScoreShare + " on "+ mapName + " with " + currentWeapon + " - “REPUBLEAGUE: Training Grounds” Android & iOS - REPUBLEAGUE / #challengeaccepted #republeague" ).SetUrl( "https://www.republeague.com/" )
            .SetCallback( ( result, shareTarget ) => Debug.Log( "Shared Score: " + highScoreShare + ", Map: " + mapName + ", Current Weapon: " + currentWeapon ) )
            .Share();
    }
}
