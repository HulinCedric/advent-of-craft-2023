namespace Day13.Tests;

public static class CommentSetup
{
    public static Comment SameOnTheNextDay(this Comment comment)
        => comment with { CreationDate = comment.CreationDate.AddDays(1) };
}