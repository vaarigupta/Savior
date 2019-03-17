using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class voice : MonoBehaviour
{
    // Start is called before the first frame update
    KeywordRecognizer keywordRecog;
    public string[] questions;
    public AudioSource[] sound;

    void Start()
    {

        Debug.Log("Welcome to SHIELD");
        keywordRecog = new KeywordRecognizer(questions);
        keywordRecog.OnPhraseRecognized += RecognizedSpeech;
        keywordRecog.Start();

        sound = GetComponent<AudioSource[]>();
        sound[0].Play(0);
    }

    void RecognizedSpeech(PhraseRecognizedEventArgs args)
    {
        Debug.Log(args.text);
        Debug.Log("keyword : " + args.text + "; Confidence : " + args.confidence);
        ActionPerformer(args.text);
    }


    void ActionPerformer(string command)
    {
       
        if (command.Contains("rob"))
        {
            print("Welcome student");
            // String path = @"A:\HackOver\LOGS";
            // using (StreamWriter sr = File.AppendText(path))
            // {
            //     sr.WriteLine("Name after conversion goes here");
            //     sr.Close();
            // }
            sound[1].Play(0); // 1 second = 11000
        }
        if (command.Contains("ten"))
        {
            print("Age registered");
            // String path = @"C:\Users\Nilesh\Desktop\Research Paper\LOG\name.txt";
            // using (StreamWriter sr = File.AppendText(path))
            // {
            //     sr.WriteLine("Age sent");
            //     sr.Close();
            // }

            sound[2].Play(0);
        }

       if (command.Contains("good"))
        {
            print("Mood check");
            // String path =@"A:\HackOver\LOGS";
            // using (StreamWriter sr = File.AppendText(path))
            // {
            //     sr.WriteLine("Fine");
            //     sr.Close();
            // }

            sound[3].Play(0);
        }


       

    }

   }

