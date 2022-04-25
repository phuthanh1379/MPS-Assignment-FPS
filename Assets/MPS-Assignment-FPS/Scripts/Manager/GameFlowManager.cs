using System;
using Scripts.Characteristics;
using Scripts.Common;
using Scripts.Player;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Manager
{
    public class GameFlowManager : MonoBehaviour
    {
        public bool GameIsEnding { get; private set; }

        [Header("Settings")] 
        // [SerializeField] private CanvasGroup endGameFadeCanvasGroup;
        [SerializeField] private PlayerController playerPrefab;
        [SerializeField] private float endSceneLoadDelay;
        [SerializeField] private float timeLoadEndGameScene;

        [Header("References")]
        [SerializeField] private EnemyManager enemyManager;
        [SerializeField] private PopupManager popupManager;
        [SerializeField] private PlayerController player; 

        #region Unity Methods

        private void Start()
        {
            Init();
        }

        private void Update()
        {
            if (GameIsEnding)
            {
                var timeRatio = 1 - (timeLoadEndGameScene - Time.time) / endSceneLoadDelay;
                // endGameFadeCanvasGroup.alpha = timeRatio;

                // AudioUtility.SetMasterVolume(1 - timeRatio);

                // See if it's time to load the end scene (after the delay)
                if (Time.time >= timeLoadEndGameScene)
                {
                    // SceneManager.LoadScene(m_SceneToLoad);
                    popupManager.ShowPopup(GameConstants.p_EndGameMenu);
                    GameIsEnding = false;
                }
            }
            else
            {
                // if (m_ObjectiveManager.AreAllObjectivesCompleted())
                //     EndGame(true);

                // Test if player died
                if (player.IsDead)
                    EndGame(false);
            }
        }

        #endregion

        #region Methods

        private void Init()
        {
            // Init enemies
            enemyManager.Init(10);
            
            // Spawn player
            player.Init();
        }
        
        private void EndGame(bool win)
        {
            // unlocks the cursor before leaving the scene, to be able to click buttons
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            // Remember that we need to load the appropriate end scene after a delay
            GameIsEnding = true;
            // endGameFadeCanvasGroup.gameObject.SetActive(true);
            
            // // Win game
            // if (win)
            // {
            //     m_SceneToLoad = winSceneName;
            //     timeLoadEndGameScene = Time.time + endSceneLoadDelay + delayBeforeFadeToBlack;
            //
            //     // Play a sound on win
            //     // var audioSource = gameObject.AddComponent<AudioSource>();
            //     // audioSource.clip = victorySound;
            //     // audioSource.playOnAwake = false;
            //     // audioSource.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.HUDVictory);
            //     // audioSource.PlayScheduled(AudioSettings.dspTime + delayBeforeWinMessage);
            //
            //     // create a game message
            //     var message = Instantiate(WinGameMessagePrefab).GetComponent<DisplayMessage>();
            //     if (message)
            //     {
            //         message.delayBeforeShowing = delayBeforeWinMessage;
            //         message.GetComponent<Transform>().SetAsLastSibling();
            //     }
            // }
            // // Lose game
            // else
            // {
            //     m_SceneToLoad = loseSceneName;
            //     timeLoadEndGameScene = Time.time + endSceneLoadDelay;
            // }
        }

        #endregion
    }
}