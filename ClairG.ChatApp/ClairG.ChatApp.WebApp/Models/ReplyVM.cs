using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClairG.ChatApp.WebApp.Models
{
    public class ReplyVM
    {
        [Required]
        public string Reply { get; set; } //<input type="text" name="Reply" />

        public int CommendId { get; set; } //<input type="hidden" name="CommendId" value="@comment.Id"/>
    }
}