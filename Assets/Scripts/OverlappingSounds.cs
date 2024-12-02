using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverlappingSounds : MonoBehaviour
{
    public AudioClip greenPegHit, greenPegHit2, greenPegHit3, greenPegHit4, greenPegHit5;
    public AudioClip prestigePegHit1, prestigePegHit2;
    public AudioClip goldPeg1, goldPeg2;
    public AudioClip mainShooter1, mainShooter2, mainShooter3;
    public AudioClip bucket1, bucket2;
    public AudioClip redPeg1, redPeg2;
    public AudioClip bombPeg1;
    public AudioClip rainbowPeg1, ranbowPeg2;
    public AudioClip purplePeg1;

    public AudioSource greenPegSource, prestigePegSource, goldPegSource, bucketSource, redPegSource, mainShooterSource, bombPegSource, purplePegSource, rainbowPegSource;

    public int greenHit;
    public int totalSounds;

    public void Awake()
    {
        totalSounds = 25;

        if (!PlayerPrefs.HasKey("saveBucketSlider")) { bucketSlider.value = 1f;  }
        else { bucketSlider.value = PlayerPrefs.GetFloat("saveBucketSlider"); bucketSource.volume = bucketSlider.value; }

        if (!PlayerPrefs.HasKey("savePegSlider")) { pegSlider.value = 0.96f; }
        else
        { 
            pegSlider.value = PlayerPrefs.GetFloat("savePegSlider");
            greenPegSource.volume = pegSlider.value;

            goldPegSlider.value = pegSlider.value;
            goldPegSource.volume = goldPegSlider.value;

            prestigePegSlider.value = pegSlider.value;
            prestigePegSource.volume = prestigePegSlider.value;

            redPegSlider.value = pegSlider.value;
            redPegSource.volume = redPegSlider.value;

            bombPegSlider.value = pegSlider.value;
            bombPegSource.volume = bombPegSlider.value;

            rainbowPegSlider.value = pegSlider.value;
            rainbowPegSource.volume = rainbowPegSlider.value;

            purplePegSlider.value = pegSlider.value;
            purplePegSource.volume = purplePegSlider.value;
        }
    }

    //SFX_UI_Appear_Coin_1

    public int testInt;
    public void TestSound()
    {
        testInt += 1;
        //Debug.Log(testInt);
        for (int i = 0; i < testInt; i++)
        {
            HitGreenPegSound();
        }
    }

    public int soundsPlaying;

    #region Green peg sounds
    public void HitGreenPegSound()
    {
        if (soundsPlaying >= totalSounds)
        {
            return; 
        }

        greenPegSource.pitch = Random.Range(0.9f, 1.15f);

        int random;

        do
        {
            random = Random.Range(1, 6);
        } while (random == greenHit);
        greenHit = random;

        soundsPlaying += 1;
        AudioClip clipToPlay = null;

        switch (random)
        {
            case 1: clipToPlay = greenPegHit; break;
            case 2: clipToPlay = greenPegHit2; break;
            case 3: clipToPlay = greenPegHit3; break;
            case 4: clipToPlay = greenPegHit4; break;
            case 5: clipToPlay = greenPegHit5; break;
        }

        if (clipToPlay != null)
        {
            greenPegSource.PlayOneShot(clipToPlay);
            StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
        }
    }
    #endregion

    #region prestige peg sounds
    public int prestigePegHit;
    public void HitPrestigePeg()
    {
        if (soundsPlaying >= totalSounds)
        {
            return;
        }
        soundsPlaying += 1;
        prestigePegSource.pitch = Random.Range(0.9f, 1.15f);

        int random;

        do
        {
            random = Random.Range(1, 3);
        } while (random == prestigePegHit);
        prestigePegHit = random;

        AudioClip clipToPlay = null;

        switch (random)
        {
            case 1: clipToPlay = prestigePegHit1; break;
            case 2: clipToPlay = prestigePegHit2; break;
        }

        if (clipToPlay != null)
        {
            prestigePegSource.PlayOneShot(clipToPlay);
            StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
        }
    }
    #endregion

    #region gold peg sounds
    public int goldPegHit;

    public void HitGoldPeg()
    {
        if (soundsPlaying >= totalSounds)
        {
            return;
        }
        soundsPlaying += 1;
        goldPegSource.pitch = Random.Range(0.9f, 1.15f);

        int random;

        do
        {
            random = Random.Range(1, 3);
        } while (random == goldPegHit);
        goldPegHit = random;

        AudioClip clipToPlay = null;

        switch (random)
        {
            case 1: clipToPlay = goldPeg1; break;
            case 2: clipToPlay = goldPeg2; break;
        }

        if (clipToPlay != null)
        {
            goldPegSource.PlayOneShot(clipToPlay);
            StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
        }
    }
    #endregion

    #region hit bucket
    public int bucketHit;
    public void HitBucket()
    {
        if (soundsPlaying >= totalSounds)
        {
            return;
        }

        float textSpawnChance = 0;

        if (BallUpgrades.textSpawnChance < 15) { textSpawnChance = 0; }
        else { textSpawnChance = BallUpgrades.textSpawnChance + 10; }

        if(textSpawnChance > 93) { textSpawnChance = 93; }

        float random2 = Random.Range(0f, 100f);
        if(random2 < textSpawnChance) { return; }

        soundsPlaying += 1;
        bucketSource.pitch = Random.Range(0.9f, 1.15f);

        int random;

        do
        {
            random = Random.Range(1, 3);
        } while (random == bucketHit);
        bucketHit = random;

        AudioClip clipToPlay = null;

        switch (random)
        {
            case 1: clipToPlay = bucket1; break;
            case 2: clipToPlay = bucket2; break;
        }

        if (clipToPlay != null)
        {
            bucketSource.PlayOneShot(clipToPlay);
            StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
        }
    }
    #endregion

    #region hit red peg
    //Puzzle_Game_Magic_Item_Unlock_4
    public int redPEgHit;
    public void HitRedPeg()
    {
        if (soundsPlaying >= totalSounds)
        {
            return;
        }
        soundsPlaying += 1;
        redPegSource.pitch = Random.Range(0.9f, 1.15f);

        int random;

        do
        {
            random = Random.Range(1, 3);
        } while (random == redPEgHit);
        redPEgHit = random;

        AudioClip clipToPlay = null;

        switch (random)
        {
            case 1: clipToPlay = redPeg1; break;
            case 2: clipToPlay = redPeg2; break;
        }

        if (clipToPlay != null)
        {
            redPegSource.PlayOneShot(clipToPlay);
            StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
        }
    }
    #endregion

    #region main shooter
    public int mainShooterHit;
    public void HitMainShooter()
    {
        if (soundsPlaying >= totalSounds)
        {
            return;
        }
        soundsPlaying += 1;
        mainShooterSource.pitch = Random.Range(0.85f, 1.1f);

        int random = Random.Range(1,4);
        
        AudioClip clipToPlay = null;
        switch (random)
        {
            case 1: clipToPlay = mainShooter1; break;
            case 2: clipToPlay = mainShooter1; break;
            case 3: clipToPlay = mainShooter1; break;
        }

        if (clipToPlay != null)
        {
            mainShooterSource.PlayOneShot(clipToPlay);
            StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
        }
    }
    #endregion

    #region hit bomb peg

    public void HitBombPeg()
    {
        if (soundsPlaying >= totalSounds)
        {
            return;
        }
        soundsPlaying += 1;

        bombPegSource.pitch = Random.Range(0.85f, 1.1f);

        AudioClip clipToPlay = null;
        clipToPlay = bombPeg1;

        if (clipToPlay != null)
        {
            bombPegSource.PlayOneShot(clipToPlay);
            StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
        }
    }
    #endregion

    #region hit purple peg
    public void HitPurplePeg()
    {
        if (soundsPlaying >= totalSounds)
        {
            return;
        }
        soundsPlaying += 1;

        AudioClip clipToPlay = null;
        clipToPlay = purplePeg1;

        if (clipToPlay != null)
        {
            purplePegSource.PlayOneShot(clipToPlay);
            StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
        }
    }
    #endregion

    #region hit rainbow peg
    public void HitRainbowPeg()
    {
        if (soundsPlaying >= totalSounds)
        {
            return;
        }
        soundsPlaying += 1;


        bombPegSource.pitch = Random.Range(0.85f, 1.1f);

        AudioClip clipToPlay = null;
        clipToPlay = rainbowPeg1;

        if (clipToPlay != null)
        {
            rainbowPegSource.PlayOneShot(clipToPlay);
            StartCoroutine(WaitForSoundToFinish(clipToPlay.length));
        }
    }
    #endregion

    public Slider bucketSlider;
    public void SetBucketVolume()
    {
        bucketSource.volume = bucketSlider.value;
        PlayerPrefs.SetFloat("saveBucketSlider", bucketSlider.value);
    }

    public Slider pegSlider;

    public Slider goldPegSlider, prestigePegSlider, redPegSlider, bombPegSlider, rainbowPegSlider, purplePegSlider;

    public void SetPegVolume()
    {
        greenPegSource.volume = pegSlider.value;
        PlayerPrefs.SetFloat("savePegSlider", pegSlider.value);

        goldPegSlider.value = pegSlider.value;
        goldPegSource.volume = goldPegSlider.value;

        prestigePegSlider.value = pegSlider.value;
        prestigePegSource.volume = prestigePegSlider.value;

        redPegSlider.value = pegSlider.value;
        redPegSource.volume = redPegSlider.value;

        bombPegSlider.value = pegSlider.value;
        bombPegSource.volume = bombPegSlider.value;

        rainbowPegSlider.value = pegSlider.value;
        rainbowPegSource.volume = rainbowPegSlider.value;

        purplePegSlider.value = pegSlider.value;
        purplePegSource.volume = purplePegSlider.value;
    }

    private IEnumerator WaitForSoundToFinish(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        soundsPlaying -= 1;
    }
}
