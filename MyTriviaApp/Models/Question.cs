using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MyTriviaApp.Models;


public partial class Question
{

    public int QuestionId { get; set; }

    public int StatusId { get; set; }

    public int SubjectId { get; set; }

    public int PlayerId { get; set; }

   
    public string Question1 { get; set; } = null!;


    public string RightA { get; set; } = null!;

   
    public string WrongA1 { get; set; } = null!;

   
    public string WrongA2 { get; set; } = null!;


    public string WrongA3 { get; set; } = null!;

   
    public virtual Player Player { get; set; } = null!;

   
    public virtual Status Status { get; set; } = null!;

    
    public virtual Subject Subject { get; set; } = null!;
}
