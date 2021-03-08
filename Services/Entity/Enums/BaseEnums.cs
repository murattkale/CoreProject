using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;




public enum ActionType : int
{
    [Description("GoTo")]
    GoTo = 1,
    [Description("Content")]
    Content = 2,
}

public enum ResponseType : int
{
    [Description("Multiple Choice")]
    MultipleChoice = 1,
    [Description("Rating")]
    Rating = 2,
    [Description("Comment Box")]
    CommentBox = 3,
    [Description("Radio")]
    Radio = 4,
}

public enum DocumentType : int
{
    [Description("Text")]
    Text = 1,
    [Description("Image")]
    Image = 2,
    [Description("Video")]
    Video = 3,
    [Description("Pdf")]
    Pdf = 4,
}

public enum CategoryType : int
{
    [Description("Category1")]
    Category1 = 1,
    [Description("Category2")]
    Category2 = 2,
    [Description("Category3")]
    Category3 = 3,
}




