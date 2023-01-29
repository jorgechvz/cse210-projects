class ReminderEntry
{
    public string Prompt;
    public int EntryId;
    public DateTime Date;

    public ReminderEntry(string prompt, int entryId, DateTime date)
    {
        Prompt = prompt;
        EntryId = entryId;
        Date = date;
    }

    public override string ToString()
    {
        return $"Prompt: {Prompt}, EntryId: {EntryId}, Date: {Date}";
    }
}