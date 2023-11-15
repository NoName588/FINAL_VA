using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class Activator : MonoBehaviour
{
    public List<GameObject> objectsToActivate;  // Lista de objetos que deseas activar/desactivar
    public List<int> targetNumbers;  // Lista de targetNumbers correspondientes a cada objeto
    public UDPReciever udpReciever;  // Asegúrate de asignar el componente UDPReceiver

    public List<GameObject> randomObjects;  // Lista de objetos para activar al azar
    private int selectedRandomObjectIndex = -1;// Índice del objeto seleccionado al azar

    public GameObject lose;
    public GameObject win;
    public GameObject Empate;

    public TMP_Text uiText;
    private int powerLvl = 0;
    public TMP_Text uiText2;
    private int enemyLvl = 0;

    public GameObject myGame;
    public GameObject myGame2;

    public AudioClip audioClip; // Nuevo campo para el AudioClip
    public AudioSource audioSource;
    public AudioClip audioClip1; // Nuevo campo para el AudioClip
    public AudioSource audioSource1;

    private int previousNumber = -1;  // Inicializa con un valor que no coincida con ningún número

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource1 = GetComponent<AudioSource>();
    }

    private void Update()
    {
        int currentNumber = udpReciever.firstNumber;

        if (currentNumber != previousNumber)
        {
            // Verificar si el número no coincide con alguno de los 'targetNumbers'
            bool foundMatch = false;
            for (int i = 0; i < objectsToActivate.Count; i++)
            {
                if (currentNumber == targetNumbers[i])
                {
                    objectsToActivate[i].SetActive(true);
                    foundMatch = true;
                }
                else
                {
                    objectsToActivate[i].SetActive(false);
                }
            }

            if (!foundMatch)
            {
                // Si no se encontró una coincidencia, desactivar todos los objetos
                foreach (GameObject obj in objectsToActivate)
                {
                    obj.SetActive(false);
                }
            }

            previousNumber = currentNumber;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Activar un objeto al azar y desactivar los demás
            SelectRandomObject();

            // Determinar el resultado del juego
            DetermineOutcome(currentNumber, selectedRandomObjectIndex);
        }
    }


    private void NumrbersUp()
    {
        // Incrementar el puntaje del jugador
        powerLvl += 1;

        // Actualizar el texto con el nuevo puntaje
        uiText.text = $"Score: {powerLvl}";

        if (audioClip != null && audioSource != null)
        {
            audioSource.PlayOneShot(audioClip);
        }

        if (powerLvl % 10 == 0 && powerLvl > 0)
        {
            // Pausar el juego
            Time.timeScale = 0f;

            // Activar el GameObject cuando enemyLvl es un múltiplo de 10
            myGame2.SetActive(true);
        }

    }

    private void NumrbersEnemy()
    {
        // Incrementar el puntaje del enemigo
        enemyLvl += 1;

        // Actualizar el texto con el nuevo puntaje del enemigo
        uiText2.text = $"Score: {enemyLvl}";

        if (audioClip1 != null && audioSource1 != null)
        {
            audioSource1.PlayOneShot(audioClip1);
        }

        // Verificar si el enemigo ha alcanzado el puntaje deseado
        if (enemyLvl % 10 == 0 && enemyLvl > 0)
        {
            // Pausar el juego
            Time.timeScale = 0f;

            // Activar el GameObject cuando enemyLvl es un múltiplo de 10
            myGame.SetActive(true);
        }

    }

    private void SelectRandomObject()
    {
        // Desactivar todos los objetos al azar
        foreach (GameObject obj in randomObjects)
        {
            obj.SetActive(false);
        }

        // Seleccionar un objeto al azar
        selectedRandomObjectIndex = Random.Range(0, randomObjects.Count);
        if (selectedRandomObjectIndex >= 0 && selectedRandomObjectIndex < randomObjects.Count)
        {
            randomObjects[selectedRandomObjectIndex].SetActive(true);
        }

        // Mostrar el número de la máquina elegido al azar
        Debug.Log("Número de la máquina es: " + selectedRandomObjectIndex);
    }

    private void DetermineOutcome(int playerNumber, int machineNumber)
    {
        // Definir las reglas del juego
        if (playerNumber == machineNumber)
        {
            Empate.SetActive(true);
            lose.SetActive(false);
            win.SetActive(false);
        }
        else
        {
            bool playerWins = false;
            if (playerNumber == 0)
            {
                playerWins = machineNumber == 4;
            }
            else if (playerNumber == 1)
            {
                playerWins = machineNumber == 2 || machineNumber == 4;
            }
            else if (playerNumber == 2)
            {
                playerWins = machineNumber == 4 || machineNumber == 3;
            }
            else if (playerNumber == 3)
            {
                playerWins = machineNumber == 1 || machineNumber == 4;
            }
            else if (playerNumber == 4)
            {
                playerWins = machineNumber == 0;
            }

            if (playerWins)
            {
                win.SetActive(true);
                lose.SetActive(false);
                Empate.SetActive(false);

                if (audioClip != null && audioSource != null)
                {
                    audioSource.PlayOneShot(audioClip);
                }

                NumrbersUp();
            }
            else
            {
                win.SetActive(false);
                lose.SetActive(true);
                Empate.SetActive(false);

                if (audioClip1 != null && audioSource1 != null)
                {
                    audioSource1.PlayOneShot(audioClip1);
                }

                NumrbersEnemy();
            }
        }
    }

}

