using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore8.Demo4_RawSql;

public class BlogPost
{
    public BlogPost(string blogTitle, string content, DateOnly publishedOn)
    {
        BlogTitle = blogTitle;
        Content = content;
        PublishedOn = publishedOn;
    }

    public int Id { get; private set; }

    [Column("Title")]
    public string BlogTitle { get; set; }

    public string Content { get; set; }
    public DateOnly PublishedOn { get; set; }
    public int BlogId { get; set; }
}
