class Reminder
{
    private List<ReminderEntry> _reminders;

    public Reminder()
    {
        _reminders = new List<ReminderEntry>();
    }

    public void SetReminder(string prompt, int entryId, DateTime date)
    {
        _reminders.Add(new ReminderEntry(prompt, entryId, date));
    }

    public void ViewReminders()
    {
        foreach (var reminder in _reminders)
        {
            Console.WriteLine(reminder.ToString());
        }
    }

    public void RemoveReminder(int entryId)
    {
        _reminders.RemoveAll(x => x.EntryId == entryId);
    }
}