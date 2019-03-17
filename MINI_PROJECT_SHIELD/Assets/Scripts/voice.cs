using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class voice : MonoBehaviour
{
   
    KeywordRecognizer keywordRecog;
    public string[] questions;
    private Animator anim;
    public AudioSource[] sound;

    void Start()
    {

        Debug.Log("Welcome to SHIELD");
        keywordRecog = new KeywordRecognizer(questions);
        keywordRecog.OnPhraseRecognized += RecognizedSpeech;
        keywordRecog.Start();

        anim = GetComponent<Animator>();
        sound = GetComponent<AudioSource[]>();
        sound[0].Play(0);
    }

    void RecognizedSpeech(PhraseRecognizedEventArgs args)
    {
        //Debug.Log(args.text);
        Debug.Log("keyword : " + args.text + "; Confidence : " + args.confidence);
        ActionPerformer(args.text);
    }


    void ActionPerformer(string command)
    {
       
        if (command.Contains("Good"))
        {
            print("Child is good ");
            // String path = @"A:\HackOver\LOGS";
            // using (StreamWriter sr = File.AppendText(path))
            // {
            //     sr.WriteLine("Name after conversion goes here");
            //     sr.Close();
            // }
            anim.Play("Run", -1, 0);
            sound[1].Play(0); // 1 second = 11000
        }
        if (command.Contains("No"))
        {
            print("Good Touch explaination");
            // String path = @"C:\Users\Nilesh\Desktop\Research Paper\LOG\name.txt";
            // using (StreamWriter sr = File.AppendText(path))
            // {
            //     sr.WriteLine("Age sent");
            //     sr.Close();
            // }
            anim.Play("Land", -1, 0);
            sound[2].Play(0);
            sound[3].Play(0);
        }

       if (command.Contains("yes"))
        {
            print("Mood check");
            // String path =@"A:\HackOver\LOGS";
            // using (StreamWriter sr = File.AppendText(path))
            // {
            //     sr.WriteLine("Fine");
            //     sr.Close();
            // }
            anim.Play("Jab", -1, 0);
            sound[4].Play(0);
            sound[5].Play(0);
        }


       

    }

   }

