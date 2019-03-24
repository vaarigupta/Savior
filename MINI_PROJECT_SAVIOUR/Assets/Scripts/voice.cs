using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.IO;

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
       
        if (command.Contains("good") || command.Contains("fine") ||command.Contains("perfect")  )
        {
           // print("Child is good ");
            sound[1].PlayDelayed(0); // 1 second = 11000
            String path = @"A:\Unity_AR\MINI_PROJECT\MINI_PROJECT_SHIELD\Logs\data.txt";
            using (StreamWriter sr = File.AppendText(path))
             {
                sr.WriteLine("Response: " + command);
                sr.Close();
             }
        }
        if (command.Contains("no") || command.Contains("nopes") || command.Contains("no idea"))
        {
            //print("Good Touch explaination");
            sound[2].PlayDelayed(0);
            String path = @"A:\Unity_AR\MINI_PROJECT\MINI_PROJECT_SHIELD\Logs\data.txt";
            using (StreamWriter sr = File.AppendText(path))
             {
                sr.WriteLine("Response: " + command);
                sr.Close();
             }
            
        }

       if (command.Contains("yes") || command.Contains("Yup"))
        {
            //print("Mood check");
            sound[3].PlayDelayed(0);
            anim.Play("run",-1,0);
            String path = @"A:\Unity_AR\MINI_PROJECT\MINI_PROJECT_SHIELD\Logs\data.txt";
            using (StreamWriter sr = File.AppendText(path))
             {
                sr.WriteLine("Response: " + command);
                sr.Close();
             }
           
        }  
        if(command.Contains("thanks") || command.Contains("thank you") || command.Contains("so much"))
        {
            sound[4].PlayDelayed(0);
            String path = @"A:\Unity_AR\MINI_PROJECT\MINI_PROJECT_SHIELD\Logs\data.txt";
            using (StreamWriter sr = File.AppendText(path))
             {
                sr.WriteLine("Response: " + command);
                sr.Close();
             }
        }

    }

   }



   // String path = @"C:\Users\Nilesh\Desktop\Research Paper\LOG\name.txt";
            // using (StreamWriter sr = File.AppendText(path))
            // {
            //     sr.WriteLine("Age sent");
            //     sr.Close();
            // }
            //anim.Play("Land", -1, 0);

             // String path =@"A:\HackOver\LOGS";
            // using (StreamWriter sr = File.AppendText(path))
            // {
            //     sr.WriteLine("Fine");
            //     sr.Close();
            // }
           // anim.Play("Jab", -1, 0);

            // String path = @"A:\HackOver\LOGS";
            // using (StreamWriter sr = File.AppendText(path))
            // {
            //     sr.WriteLine("Name after conversion goes here");
            //     sr.Close();
            // }
           // anim.Play("Run", -1, 0);

