namespace AwesomeDevEventsAPI.Entities
{
    public class DevEvent
    {
        public DevEvent()
        {
            Speakers = new List<DevEventSpeaker>();
            IsDeleted = false;
        }


        public Guid Id { get; set; }
        public String Title { get; set; }
        public String Description { get; set; }

        public DateTime StartedDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<DevEventSpeaker> Speakers { get; set; }
        public bool IsDeleted { get; set; }

        public void Update(String title, string description, DateTime startedDate, DateTime EndDate)
        {
            Title = title;
            Description = description;
            StartedDate = startedDate;
            EndDate = EndDate;

        }

        public void Delete()
        {
            IsDeleted = true;

        }

    }
}
