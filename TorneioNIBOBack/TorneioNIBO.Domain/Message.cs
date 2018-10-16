namespace TorneioNIBO.Domain
{
    public class Message
    {
        public Message(string code, MessageType type, string description)
        {
            this.code = code;
            this.type = type;
            this.description = description;
        }

        public string code { get; set; }
        public MessageType type { get; set; }
        public string description { get; set; }
    }
}
