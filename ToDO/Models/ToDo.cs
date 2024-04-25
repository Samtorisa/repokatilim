using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDO.Models;

public partial class ToDo
{
    public long id { get; set; }

    public string Title { get; set; } = null!;

    public string Content { get; set; } = null!;


    public string isComplete { get; set; }


    public string Priority { get; set; } 
}

