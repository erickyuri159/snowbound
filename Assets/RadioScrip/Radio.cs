using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{

    // Array para armazenar as m�sicas
    public AudioClip[] musicas;

    // Refer�ncia ao componente AudioSource
    private AudioSource audioSource;

    void Start()
    {
        // Obt�m o componente AudioSource do objeto
        audioSource = GetComponent<AudioSource>();

        // Verifica se h� m�sicas na lista
        if (musicas.Length > 0)
        {
            // Seleciona uma m�sica aleat�ria para come�ar
            int indiceMusicaAleatoria = Random.Range(0, musicas.Length);
            AudioClip musicaAleatoria = musicas[indiceMusicaAleatoria];

            // Define a m�sica selecionada para tocar
            audioSource.clip = musicaAleatoria;

            // Toca a m�sica
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Nenhuma m�sica encontrada na lista!");
        }
    }

    // M�todo para trocar de m�sica
    public void TrocarMusica()
    {
        // Seleciona uma m�sica aleat�ria da lista
        int indiceMusicaAleatoria = Random.Range(0, musicas.Length);
        AudioClip novaMusica = musicas[indiceMusicaAleatoria];

        // Define a nova m�sica para tocar
        audioSource.clip = novaMusica;

        // Toca a nova m�sica
        audioSource.Play();
    }

    // M�todo para pausar ou retomar a reprodu��o da m�sica
    public void AlternarPausarContinuar()
    {
        // Verifica se a m�sica est� tocando
        if (audioSource.isPlaying)
        {
            // Pausa a reprodu��o da m�sica
            audioSource.Pause();
        }
        else
        {
            // Continua a reprodu��o da m�sica
            audioSource.Play();
        }
    }
}

